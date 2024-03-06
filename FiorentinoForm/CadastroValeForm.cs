using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class CadastroValeForm : parent
    {
        public PersonBenefits PersonBenefit { get; }

        public CadastroValeForm()
        {
            InitializeComponent();
           
        }

        public CadastroValeForm(PersonBenefits personBenefit)
        {
            InitializeComponent();
            PersonBenefit = personBenefit;
            titleCadastroVale.Text = "Atualizar Beneficio";
            button1.Text = "Atualizar";
 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CadastroValeForm_Load(object sender, EventArgs e)
        {
            comboBoxFunc.Items.AddRange(ctx.People.Select(x => x.Name).ToArray());
            comboBoxBeneficio.Items.AddRange(ctx.Benefits.Select(x => x.Name).ToArray());

            comboBox1.Items.Add("Dia");
            comboBox1.Items.Add("Mês");
            if (PersonBenefit != null)
            {
                comboBoxFunc.SelectedIndex = comboBoxFunc.Items.IndexOf(PersonBenefit.People.Name);
                comboBoxBeneficio.SelectedIndex = comboBoxBeneficio.Items.IndexOf(PersonBenefit.Benefits.Name);
                numericUpDown1.Value = decimal.Parse( PersonBenefit.Amount);
                var bit = PersonBenefit.Occurrence == 0 ? "Dia" : "Mês";
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(bit);
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(PersonBenefit != null)
            {
                var pb = ctx.PersonBenefits.Find(PersonBenefit.ID);
                int idPerson = int.Parse(ctx.People.Where(x => x.Name == comboBoxFunc.SelectedItem.ToString()).FirstOrDefault().ID.ToString());
                int idBeneficio = int.Parse(ctx.Benefits.Where(x => x.Name == comboBoxBeneficio.SelectedItem.ToString()).FirstOrDefault().ID.ToString());

                int bit = comboBox1.SelectedItem == "Dia" ? 0 : 1;
                pb.PersonID = idPerson;
                pb.BenefitID = idBeneficio;
                pb.Amount = numericUpDown1.Value.ToString();
                pb.SolicitationDate = DateTime.Now;
                pb.Occurrence = bit;


                ctx.Entry(pb).CurrentValues.SetValues(pb);
                ctx.SaveChanges();
              MessageBox.Show(  "Benefício atualizado com sucesso!");

            }
            else
            {

            if(numericUpDown1.Value < 1 || comboBoxFunc.SelectedIndex < 0 || comboBoxBeneficio.SelectedIndex < 0  || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Preencha todos os campos corretamnete");
                return;
            }

            int idPerson = int.Parse(ctx.People.Where(x => x.Name == comboBoxFunc.SelectedItem.ToString()).FirstOrDefault().ID.ToString());
            int idBeneficio = int.Parse(ctx.Benefits.Where(x => x.Name == comboBoxBeneficio.SelectedItem.ToString()).FirstOrDefault().ID.ToString());

            int bit = comboBox1.SelectedItem == "Dia" ? 0 : 1;

            var personBenefits = ctx.People.ToList();
         
            PersonBenefits pb = new PersonBenefits();
            
            pb.PersonID = idPerson;
            pb.BenefitID = idBeneficio;
            pb.Amount  = numericUpDown1.Value.ToString();
            pb.SolicitationDate = DateTime.Now;
            pb.Occurrence = bit;

            ctx.PersonBenefits.Add(pb);
            ctx.SaveChanges();

            MessageBox.Show("Beneficio cadastrado com sucesso");
            }
            Hide();
            new LancamentoVale().ShowDialog();
            Close();

        }
    }
}
