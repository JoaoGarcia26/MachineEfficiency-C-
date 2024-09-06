namespace Projeto_EficienciaXTemperatura.View
{
    partial class ScreenRegistrarMaquina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenRegistrarMaquina));
            label1 = new Label();
            button1 = new Button();
            txtNomeMaquina = new TextBox();
            txtLatitude = new TextBox();
            label2 = new Label();
            txtLongitude = new TextBox();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(51, 33);
            label1.Name = "label1";
            label1.Size = new Size(157, 23);
            label1.TabIndex = 0;
            label1.Text = "Nome da maquina:";
            // 
            // button1
            // 
            button1.Location = new Point(392, 59);
            button1.Name = "button1";
            button1.Size = new Size(136, 56);
            button1.TabIndex = 1;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtNomeMaquina
            // 
            txtNomeMaquina.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtNomeMaquina.Location = new Point(56, 59);
            txtNomeMaquina.Name = "txtNomeMaquina";
            txtNomeMaquina.Size = new Size(237, 30);
            txtNomeMaquina.TabIndex = 2;
            // 
            // txtLatitude
            // 
            txtLatitude.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtLatitude.Location = new Point(56, 139);
            txtLatitude.Name = "txtLatitude";
            txtLatitude.Size = new Size(237, 30);
            txtLatitude.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 113);
            label2.Name = "label2";
            label2.Size = new Size(76, 23);
            label2.TabIndex = 3;
            label2.Text = "Latitude:";
            // 
            // txtLongitude
            // 
            txtLongitude.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtLongitude.Location = new Point(56, 224);
            txtLongitude.Name = "txtLongitude";
            txtLongitude.Size = new Size(237, 30);
            txtLongitude.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 198);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 5;
            label3.Text = "Longitude:";
            // 
            // button2
            // 
            button2.Location = new Point(392, 198);
            button2.Name = "button2";
            button2.Size = new Size(136, 56);
            button2.TabIndex = 7;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ScreenRegistrarMaquina
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 281);
            Controls.Add(button2);
            Controls.Add(txtLongitude);
            Controls.Add(label3);
            Controls.Add(txtLatitude);
            Controls.Add(label2);
            Controls.Add(txtNomeMaquina);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ScreenRegistrarMaquina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Maquinas | EficienciaXTemperatura";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox txtNomeMaquina;
        private TextBox txtLatitude;
        private Label label2;
        private TextBox txtLongitude;
        private Label label3;
        private Button button2;
    }
}