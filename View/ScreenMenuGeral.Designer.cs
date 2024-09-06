namespace Projeto_EficienciaXTemperatura
{
    partial class ScreenMenuGeral
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenMenuGeral));
            menuStrip1 = new MenuStrip();
            maquinasToolStripMenuItem = new ToolStripMenuItem();
            cadastrarNovaMaquinaToolStripMenuItem = new ToolStripMenuItem();
            maquinaBindingSource = new BindingSource(components);
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            maquinaBindingSource1 = new BindingSource(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maquinaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maquinaBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { maquinasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1289, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // maquinasToolStripMenuItem
            // 
            maquinasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarNovaMaquinaToolStripMenuItem });
            maquinasToolStripMenuItem.Name = "maquinasToolStripMenuItem";
            maquinasToolStripMenuItem.Size = new Size(87, 24);
            maquinasToolStripMenuItem.Text = "Maquinas";
            // 
            // cadastrarNovaMaquinaToolStripMenuItem
            // 
            cadastrarNovaMaquinaToolStripMenuItem.Name = "cadastrarNovaMaquinaToolStripMenuItem";
            cadastrarNovaMaquinaToolStripMenuItem.Size = new Size(256, 26);
            cadastrarNovaMaquinaToolStripMenuItem.Text = "Cadastrar Nova Maquina";
            cadastrarNovaMaquinaToolStripMenuItem.Click += cadastrarNovaMaquinaToolStripMenuItem_Click;
            // 
            // maquinaBindingSource
            // 
            maquinaBindingSource.DataSource = typeof(Model.Maquina);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(41, 58);
            listView1.Name = "listView1";
            listView1.Size = new Size(584, 466);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nome da Maquina";
            columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Eficiencia (%)";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Temperatura (°C)";
            columnHeader3.Width = 200;
            // 
            // maquinaBindingSource1
            // 
            maquinaBindingSource1.DataSource = typeof(Model.Maquina);
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(709, 58);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(539, 466);
            cartesianChart1.TabIndex = 7;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(914, 35);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 8;
            label1.Text = "Gráfico - Eficiencia x Tempo";
            // 
            // ScreenMenuGeral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 555);
            Controls.Add(label1);
            Controls.Add(cartesianChart1);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "ScreenMenuGeral";
            StartPosition = FormStartPosition.CenterScreen;
            Activated += ScreenMenuGeral_Activated;
            Load += ScreenMenuGeral_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maquinaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)maquinaBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem maquinasToolStripMenuItem;
        private ToolStripMenuItem cadastrarNovaMaquinaToolStripMenuItem;
        private BindingSource maquinaBindingSource;
        private ListView listView1;
        private BindingSource maquinaBindingSource1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
    }
}