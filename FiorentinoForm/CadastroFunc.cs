using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class CadastroFunc : FiorentinoForm.parent
    {
        public CadastroFunc()
        {
            InitializeComponent();
        }
        public People Usuario { get; }

        public CadastroFunc(People usuario)
        {
            Usuario = usuario;
        }


        private void CadastroFunc_Load(object sender, EventArgs e)
        {
            comboTipo.Items.AddRange(ctx.PersonTypes.Select(x => x.Name).ToArray());


            var masks = ctx.DocumentTypes.ToList();

            cpf.Mask = masks.Where(x => x.Name == "CPF").FirstOrDefault().Validation;
            rg.Mask = masks.Where(x => x.Name == "RG").FirstOrDefault().Validation;
            passaporte.Mask = masks.Where(x => x.Name == "Passaport").FirstOrDefault().Validation;
            reservista.Mask = masks.Where(x => x.Name == "Reservista").FirstOrDefault().Validation;

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
              comboTipo.SelectedIndex < 0 ||
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
                int tipoUsuario = int.Parse(ctx.PersonTypes.Where(x => x.Name == comboTipo.SelectedItem.ToString()).FirstOrDefault().ID.ToString());
                p.TypeID = tipoUsuario;
                ctx.People.Add(p);
                ctx.SaveChanges();

            tabControl1.SelectedTab = tabPage2;
            }else   if (tabControl1.SelectedIndex == 1)
            {

            if (rg.Text == null || string.IsNullOrEmpty(cpf.Text))
            {
                MessageBox.Show("Preencha todos os campos corretamente");
                tabControl1.SelectedTab = tabPage2;
                return;

            }
                var ultimoUser = ctx.People.OrderByDescending(x => x.ID).FirstOrDefault();
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









        }
        //private bool VerificarDigito()
        //{
        //    var pattern = @"^(?=.*\d)$";


        //}


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                userFotoCadastro.Image = Image.FromFile(ofd.FileName);
            }

        }
    }
}
