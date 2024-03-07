using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class CadastroFunc : FiorentinoForm.parent
    {
        public List<People> ListaDependentes { get; set; } = new List<People>();
        public List<People> ListaGerentes { get; set; } = new List<People>();


        int idCesta;
        int idVale;
        int idAssistencia;
        int idSegura;
        int idPeople;


        public CadastroFunc()
        {
            InitializeComponent();
        }
        public People Usuario { get; }

        public CadastroFunc(People usuario)
        {
            Usuario = usuario;
            InitializeComponent();
        }


        private void CadastroFunc_LoadAsync(object sender, EventArgs e)
        {
            comboCargo.Items.AddRange(ctx.Roles.Select(x => x.Name).ToArray());

    


            var masks = ctx.DocumentTypes.ToList();

            cpf.Mask = masks.Where(x => x.Name == "CPF").FirstOrDefault().Validation;
            rg.Mask = masks.Where(x => x.Name == "RG").FirstOrDefault().Validation;
            passaporte.Mask = masks.Where(x => x.Name == "Passaport").FirstOrDefault().Validation;
            reservista.Mask = masks.Where(x => x.Name == "Reservista").FirstOrDefault().Validation;

            comboCidades.Items.AddRange(ctx.Cities.Select(x => x.Name).ToArray());
            comboEstados.Items.AddRange(ctx.States.Select(x => x.Name).ToArray());
            comboCidades.Enabled = false;

            CarregarResponsaveisAsync();

        }
        public async Task CarregarResponsaveisAsync()
        {
            var idsDistintos = ctx.Employees.Where(x => x.ManagerID != null).ToList().Select(x => x.ManagerID).Distinct().ToList();
            //var tasks = await Task.WhenAll(idsDistintos.Select(x => ctx.People.Find(x)));
      
            foreach (var item in idsDistintos)
            {
             var gerente =   ctx.People.FirstOrDefault(x => x.ID == item);
                ListaGerentes.Add(gerente); 
            }
            comboResponsavel.Items.AddRange(ListaGerentes.Select(x => x.Name).ToArray());
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (tabControl1.SelectedIndex == 0)
            {
               if (string.IsNullOrEmpty(nameUser.Text) ||
              string.IsNullOrEmpty(emailUser.Text) ||
              comboCargo.SelectedIndex < 0 ||
              string.IsNullOrEmpty(senhaUser.Text) ||
              string.IsNullOrEmpty(confirmSenha.Text))
                {
                    tabControl1.SelectedTab = tabPage1;
                    MessageBox.Show("Preencha todos os campos corretamente!");
                    return;
                }

                if (senhaUser.Text != confirmSenha.Text)
                {
                    tabControl1.SelectedTab = tabPage1;
                    MessageBox.Show("As senhas estão diferentes");
                    return;
                }

                var emailBuscado = ctx.People.FirstOrDefault(x => x.Email == emailUser.Text);

                if (emailBuscado != null)
                {
                    tabControl1.SelectedTab = tabPage1;
                    MessageBox.Show("Email já cadastrado");
                    return;
                }
                People p = new People();
                p.Name = nameUser.Text;
                p.Email = emailUser.Text;
                p.BirthDay = dataNascimento.Value;
                p.Photo = userFotoCadastro.Name;
                p.Password = senhaUser.Text;
    
                p.TypeID = 1;
                ctx.People.Add(p);
                ctx.SaveChanges();

                tabControl1.SelectedTab = tabPage2;
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                if (rg.Text == null || string.IsNullOrEmpty(cpf.Text))
                {
                    MessageBox.Show("Preencha todos os campos corretamente");
                    tabControl1.SelectedTab = tabPage2;
                    return;

                }
                var ultimoUser = ctx.People.OrderByDescending(x => x.ID).FirstOrDefault();
                PeopleCadastro.usuario = ultimoUser;
                idPeople = ultimoUser.ID;
                Documents dcs = new Documents();
                dcs.PersonID = ultimoUser.ID;
                dcs.DocTypeID = 1;
                dcs.Value = rg.Text;
                dcs.IssueDate = rgE.Value.ToShortDateString();
                dcs.ExpirationDate = rgV.Value;

                ctx.Documents.Add(dcs);
                ctx.SaveChanges();


                Documents dcs2 = new Documents();
                dcs2.PersonID = ultimoUser.ID;
                dcs2.DocTypeID = 2;
                dcs2.Value = cpf.Text;
                dcs2.IssueDate = cpfE.Value.ToShortDateString();


                ctx.Documents.Add(dcs2);
                ctx.SaveChanges();

                if (passaporte.Text != null)
                {

                    Documents dcs3 = new Documents();
                    dcs3.PersonID = ultimoUser.ID;
                    dcs3.DocTypeID = 2;
                    dcs3.Value = passaporte.Text;
                    dcs3.IssueDate = passaporteE.Value.ToShortDateString();
                    dcs3.ExpirationDate = passaporteV.Value;


                    ctx.Documents.Add(dcs3);
                    ctx.SaveChanges();
                }


                if (reservista.Text != null)
                {

                    Documents dcs4 = new Documents();
                    dcs4.PersonID = ultimoUser.ID;
                    dcs4.DocTypeID = 2;
                    dcs4.Value = reservista.Text;
                    dcs4.IssueDate = reservistaE.Value.ToShortDateString();



                    ctx.Documents.Add(dcs4);
                    ctx.SaveChanges();
                }


                tabControl1.SelectedTab = tabPage3;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(textboxRua.Text) || string.IsNullOrEmpty(numeroAddress.Text) || string.IsNullOrEmpty(cep.Text) || comboCidades.SelectedIndex < 0 || comboEstados.SelectedIndex < 0)
                {
                    MessageBox.Show("Preenhca todos os campos corretamente");
                    return;
                }
                Addresses ads = new Addresses();

                ads.Street = textboxRua.Text;
                ads.CEP = cep.Text;
                ads.Number = int.Parse(numeroAddress.Text);
                int idCidade = int.Parse(ctx.Cities.Where(x => x.Name == comboCidades.SelectedItem.ToString()).FirstOrDefault().ID.ToString());
                ads.CityID = idCidade;


                ctx.Addresses.Add(ads);
                ctx.SaveChanges();



                var address = ctx.Addresses.OrderByDescending(x => x.ID).FirstOrDefault();
                var user = ctx.People.Find(idPeople);
                user.AddressID = address.ID;

                ctx.Entry(user).CurrentValues.SetValues(user);

                ctx.SaveChanges();

                tabControl1.SelectedTab = tabPage4;

            }
            else if (tabControl1.SelectedIndex == 3)
            {
                tabControl1.SelectedTab = tabPage5;

            }

            else if (tabControl1.SelectedIndex == 4)
            {

                if (idCesta == 5)
                {
                    PersonBenefits pb = new PersonBenefits();
                    pb.PersonID = idPeople;
                    pb.BenefitID = idCesta;
                    pb.Occurrence = 0;
                    pb.SolicitationDate = DateTime.Now;
                    ctx.PersonBenefits.Add(pb);
                    ctx.SaveChanges();
                }


                if (idVale == 6)
                {
                    PersonBenefits pb2 = new PersonBenefits();
                    pb2.PersonID = idPeople;
                    pb2.BenefitID = idVale;
                    pb2.Occurrence = 0;
                    pb2.SolicitationDate = DateTime.Now;
                    ctx.PersonBenefits.Add(pb2);
                    ctx.SaveChanges();
                }



                if (idAssistencia == 7)
                {
                    PersonBenefits pb3 = new PersonBenefits();
                    pb3.PersonID = idPeople;
                    pb3.BenefitID = idAssistencia;
                    pb3.Occurrence = 0;
                    pb3.SolicitationDate = DateTime.Now;
                }

                if (idSegura == 8)
                {
                    PersonBenefits pb4 = new PersonBenefits();
                    pb4.PersonID = idPeople;
                    pb4.BenefitID = idSegura;
                    pb4.SolicitationDate = DateTime.Now;
                    pb4.Occurrence = 0;
                    ctx.PersonBenefits.Add(pb4);
                    ctx.SaveChanges();
                }
                MessageBox.Show("Usuario cadastrado com sucesso!");
                tabControl1.SelectedTab = tabPage1;
            }





        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                userFotoCadastro.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void comboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEstados.SelectedIndex < 0)
            {
                comboCidades.Enabled = false;
                return;
            }

            comboCidades.Enabled = true;

            comboCidades.Items.Clear();

            int idEstado = int.Parse(ctx.States.Where(x => x.Name == comboEstados.SelectedItem.ToString()).FirstOrDefault().ID.ToString());

            var listaCidades = ctx.Cities.Where(x => x.StateID == idEstado).ToList();

            comboCidades.Items.AddRange(listaCidades.Select(x => x.Name).ToArray());







        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userNameD.Text) || string.IsNullOrEmpty(userEmailD.Text) || string.IsNullOrEmpty(userSenhaD.Text) || string.IsNullOrEmpty(confirmSenhaD.Text))
            {
                MessageBox.Show("Preencha todos os campos corretamente");
                return;
            }

            People p = new People();
            p.ResponsibleID = idPeople;
            p.Name = userNameD.Text;
            p.Email = userEmailD.Text;
            p.BirthDay = userNascimentoD.Value;
            p.Password = userSenhaD.Text;

            int idAddres = ctx.Addresses.OrderByDescending(x => x.ID).FirstOrDefault().ID;
            p.AddressID = idAddres;
            if (pictureBox2.Image != null)
            {
                p.Photo = pictureBox2.Image.ToString();
            }

            ctx.People.Add(p);
            ctx.SaveChanges();

            ListaDependentes.Add(p);
            LoadDependentes();
        }

        public void LoadDependentes()
        {
            dataGridView1.DataSource = ListaDependentes.Select(x => new
            {
                Nome = x.Name,
                Nascimento = x.BirthDay,
                Email = x.Email,
                Senha = x.Password,

            }).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                new AddDepenteForm().ShowDialog();
                idVale = 6;
            }
            else
            {
                idVale = 0;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                idAssistencia = 7;
            }
            else
            {
                idAssistencia = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
