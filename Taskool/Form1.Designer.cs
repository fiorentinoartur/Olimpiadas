namespace Taskool
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Entrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.link_Teclado = new System.Windows.Forms.LinkLabel();
            this.Txt_Cadastro = new System.Windows.Forms.LinkLabel();
            this.capslock_Login = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Entrar
            // 
            this.btn_Entrar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Entrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Entrar.Location = new System.Drawing.Point(303, 368);
            this.btn_Entrar.Name = "btn_Entrar";
            this.btn_Entrar.Size = new System.Drawing.Size(107, 29);
            this.btn_Entrar.TabIndex = 0;
            this.btn_Entrar.Text = "Entrar";
            this.btn_Entrar.UseVisualStyleBackColor = false;
            this.btn_Entrar.Click += new System.EventHandler(this.btn_Entrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bem-vindo ao Taskool";

            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Location = new System.Drawing.Point(259, 141);
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(225, 20);
            this.Txt_Usuario.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(314, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 1;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Usuário";

            // 
            // link_Teclado
            // 
            this.link_Teclado.AutoSize = true;
            this.link_Teclado.Location = new System.Drawing.Point(511, 144);
            this.link_Teclado.Name = "link_Teclado";
            this.link_Teclado.Size = new System.Drawing.Size(78, 13);
            this.link_Teclado.TabIndex = 4;
            this.link_Teclado.TabStop = true;
            this.link_Teclado.Text = "Teclado Virtual";
            this.link_Teclado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Teclado_LinkClicked);
            // 
            // Txt_Cadastro
            // 
            this.Txt_Cadastro.AutoSize = true;
            this.Txt_Cadastro.Location = new System.Drawing.Point(323, 423);
            this.Txt_Cadastro.Name = "Txt_Cadastro";
            this.Txt_Cadastro.Size = new System.Drawing.Size(63, 13);
            this.Txt_Cadastro.TabIndex = 4;
            this.Txt_Cadastro.TabStop = true;
            this.Txt_Cadastro.Text = "Cadastre-se";
            this.Txt_Cadastro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Txt_Cadastro_LinkClicked);
            // 
            // capslock_Login
            // 
            this.capslock_Login.AutoSize = true;
            this.capslock_Login.BackColor = System.Drawing.SystemColors.Control;
            this.capslock_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capslock_Login.ForeColor = System.Drawing.Color.Red;
            this.capslock_Login.Location = new System.Drawing.Point(256, 164);
            this.capslock_Login.Name = "capslock_Login";
            this.capslock_Login.Size = new System.Drawing.Size(145, 17);
            this.capslock_Login.TabIndex = 1;
            this.capslock_Login.Text = "CAPSLOCK ATIVADO";

            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.Txt_Cadastro);
            this.Controls.Add(this.link_Teclado);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Txt_Usuario);
            this.Controls.Add(this.capslock_Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Entrar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Entrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel link_Teclado;
        private System.Windows.Forms.LinkLabel Txt_Cadastro;
        private System.Windows.Forms.Label capslock_Login;
        private System.Windows.Forms.Timer timer1;
    }
}

