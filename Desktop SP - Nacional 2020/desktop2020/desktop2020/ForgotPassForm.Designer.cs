namespace desktop2020
{
    partial class ForgotPassForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NewPass = new System.Windows.Forms.Label();
            this.confirmPass = new System.Windows.Forms.Label();
            this.Txt_Senha = new System.Windows.Forms.TextBox();
            this.Txt_ConfirmSenha = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Txt_Security = new System.Windows.Forms.TextBox();
            this.Txt_SenhaIgual = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.Txt_ConfirmSenha);
            this.panel1.Controls.Add(this.Txt_SenhaIgual);
            this.panel1.Controls.Add(this.Txt_Security);
            this.panel1.Controls.Add(this.Txt_Senha);
            this.panel1.Controls.Add(this.confirmPass);
            this.panel1.Controls.Add(this.NewPass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(622, 248);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Favorito:";
            // 
            // NewPass
            // 
            this.NewPass.AutoSize = true;
            this.NewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPass.Location = new System.Drawing.Point(74, 90);
            this.NewPass.Name = "NewPass";
            this.NewPass.Size = new System.Drawing.Size(90, 17);
            this.NewPass.TabIndex = 0;
            this.NewPass.Text = "Nova Senha:";
            // 
            // confirmPass
            // 
            this.confirmPass.AutoSize = true;
            this.confirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPass.Location = new System.Drawing.Point(12, 127);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.Size = new System.Drawing.Size(154, 17);
            this.confirmPass.TabIndex = 0;
            this.confirmPass.Text = "Confirmação de senha:";
            // 
            // Txt_Senha
            // 
            this.Txt_Senha.Location = new System.Drawing.Point(186, 89);
            this.Txt_Senha.Name = "Txt_Senha";
            this.Txt_Senha.Size = new System.Drawing.Size(177, 20);
            this.Txt_Senha.TabIndex = 1;
            // 
            // Txt_ConfirmSenha
            // 
            this.Txt_ConfirmSenha.Location = new System.Drawing.Point(186, 124);
            this.Txt_ConfirmSenha.Name = "Txt_ConfirmSenha";
            this.Txt_ConfirmSenha.Size = new System.Drawing.Size(177, 20);
            this.Txt_ConfirmSenha.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(186, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data de Nascimento:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(186, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(177, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // Txt_Security
            // 
            this.Txt_Security.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Txt_Security.Location = new System.Drawing.Point(387, 89);
            this.Txt_Security.Name = "Txt_Security";
            this.Txt_Security.Size = new System.Drawing.Size(143, 20);
            this.Txt_Security.TabIndex = 1;
            // 
            // Txt_SenhaIgual
            // 
            this.Txt_SenhaIgual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Txt_SenhaIgual.Location = new System.Drawing.Point(387, 124);
            this.Txt_SenhaIgual.Name = "Txt_SenhaIgual";
            this.Txt_SenhaIgual.Size = new System.Drawing.Size(143, 20);
            this.Txt_SenhaIgual.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Alterar Senha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(247, 217);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(34, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Voltar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ForgotPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 248);
            this.Name = "ForgotPassForm";
            this.Text = "ForgotPassForm";
            this.Load += new System.EventHandler(this.ForgotPassForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label confirmPass;
        private System.Windows.Forms.Label NewPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Txt_ConfirmSenha;
        private System.Windows.Forms.TextBox Txt_SenhaIgual;
        private System.Windows.Forms.TextBox Txt_Security;
        private System.Windows.Forms.TextBox Txt_Senha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
    }
}