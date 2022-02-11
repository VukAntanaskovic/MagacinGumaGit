namespace MagacinGuma
{
    partial class frmPocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPocetna));
            this.tabCtr = new System.Windows.Forms.TabControl();
            this.ctxlogout = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izlogujteSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProdaja = new System.Windows.Forms.TabPage();
            this.tabMagacin = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPretragaIDGume = new System.Windows.Forms.TextBox();
            this.tabGume = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAzuriranjeId = new System.Windows.Forms.TextBox();
            this.numericAzuriranjeBrzina = new System.Windows.Forms.NumericUpDown();
            this.btnAzuriranjeGume = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAzuriranjeDimenzije = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAzuriranjeProizvodjac = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvGume = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericGumaMaxBrzina = new System.Windows.Forms.NumericUpDown();
            this.btnUnosGume = new System.Windows.Forms.Button();
            this.cmbTipGume = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGumaDimenzije = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGumaProizvodjac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPorucivanje = new System.Windows.Forms.TabPage();
            this.tabKnjizenje = new System.Windows.Forms.TabPage();
            this.tabKorisnici = new System.Windows.Forms.TabPage();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPretragaProizvodjac = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPretragaTipGume = new System.Windows.Forms.ComboBox();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.dgvPretragaGume = new System.Windows.Forms.DataGridView();
            this.tabCtr.SuspendLayout();
            this.ctxlogout.SuspendLayout();
            this.tabMagacin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabGume.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAzuriranjeBrzina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGume)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGumaMaxBrzina)).BeginInit();
            this.pnlLoading.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPretragaGume)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtr
            // 
            this.tabCtr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtr.ContextMenuStrip = this.ctxlogout;
            this.tabCtr.Controls.Add(this.tabProdaja);
            this.tabCtr.Controls.Add(this.tabMagacin);
            this.tabCtr.Controls.Add(this.tabGume);
            this.tabCtr.Controls.Add(this.tabPorucivanje);
            this.tabCtr.Controls.Add(this.tabKnjizenje);
            this.tabCtr.Controls.Add(this.tabKorisnici);
            this.tabCtr.Location = new System.Drawing.Point(3, 2);
            this.tabCtr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCtr.Name = "tabCtr";
            this.tabCtr.SelectedIndex = 0;
            this.tabCtr.Size = new System.Drawing.Size(1792, 865);
            this.tabCtr.TabIndex = 0;
            // 
            // ctxlogout
            // 
            this.ctxlogout.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxlogout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izlogujteSeToolStripMenuItem});
            this.ctxlogout.Name = "ctxlogout";
            this.ctxlogout.Size = new System.Drawing.Size(155, 28);
            // 
            // izlogujteSeToolStripMenuItem
            // 
            this.izlogujteSeToolStripMenuItem.Name = "izlogujteSeToolStripMenuItem";
            this.izlogujteSeToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.izlogujteSeToolStripMenuItem.Text = "Izlogujte se";
            this.izlogujteSeToolStripMenuItem.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabProdaja
            // 
            this.tabProdaja.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabProdaja.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabProdaja.Location = new System.Drawing.Point(4, 25);
            this.tabProdaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProdaja.Name = "tabProdaja";
            this.tabProdaja.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProdaja.Size = new System.Drawing.Size(1784, 836);
            this.tabProdaja.TabIndex = 0;
            this.tabProdaja.Text = "Prodaja";
            // 
            // tabMagacin
            // 
            this.tabMagacin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabMagacin.Controls.Add(this.dgvPretragaGume);
            this.tabMagacin.Controls.Add(this.groupBox3);
            this.tabMagacin.Location = new System.Drawing.Point(4, 25);
            this.tabMagacin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMagacin.Name = "tabMagacin";
            this.tabMagacin.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMagacin.Size = new System.Drawing.Size(1784, 836);
            this.tabMagacin.TabIndex = 1;
            this.tabMagacin.Text = "Stanje u magacinu";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnPretraga);
            this.groupBox3.Controls.Add(this.cmbPretragaTipGume);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtPretragaProizvodjac);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtPretragaIDGume);
            this.groupBox3.Location = new System.Drawing.Point(8, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1765, 76);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filteri";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Id gume";
            // 
            // txtPretragaIDGume
            // 
            this.txtPretragaIDGume.Location = new System.Drawing.Point(8, 44);
            this.txtPretragaIDGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPretragaIDGume.Name = "txtPretragaIDGume";
            this.txtPretragaIDGume.Size = new System.Drawing.Size(173, 22);
            this.txtPretragaIDGume.TabIndex = 0;
            // 
            // tabGume
            // 
            this.tabGume.Controls.Add(this.groupBox2);
            this.tabGume.Controls.Add(this.dgvGume);
            this.tabGume.Controls.Add(this.groupBox1);
            this.tabGume.Location = new System.Drawing.Point(4, 25);
            this.tabGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabGume.Name = "tabGume";
            this.tabGume.Size = new System.Drawing.Size(1784, 836);
            this.tabGume.TabIndex = 2;
            this.tabGume.Text = "Gume";
            this.tabGume.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtAzuriranjeId);
            this.groupBox2.Controls.Add(this.numericAzuriranjeBrzina);
            this.groupBox2.Controls.Add(this.btnAzuriranjeGume);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAzuriranjeDimenzije);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtAzuriranjeProizvodjac);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(909, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(865, 338);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Azuriranje gume";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Id gume:";
            // 
            // txtAzuriranjeId
            // 
            this.txtAzuriranjeId.Location = new System.Drawing.Point(584, 14);
            this.txtAzuriranjeId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAzuriranjeId.Name = "txtAzuriranjeId";
            this.txtAzuriranjeId.ReadOnly = true;
            this.txtAzuriranjeId.Size = new System.Drawing.Size(272, 22);
            this.txtAzuriranjeId.TabIndex = 12;
            // 
            // numericAzuriranjeBrzina
            // 
            this.numericAzuriranjeBrzina.DecimalPlaces = 2;
            this.numericAzuriranjeBrzina.Location = new System.Drawing.Point(8, 177);
            this.numericAzuriranjeBrzina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericAzuriranjeBrzina.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericAzuriranjeBrzina.Name = "numericAzuriranjeBrzina";
            this.numericAzuriranjeBrzina.Size = new System.Drawing.Size(849, 22);
            this.numericAzuriranjeBrzina.TabIndex = 11;
            // 
            // btnAzuriranjeGume
            // 
            this.btnAzuriranjeGume.Location = new System.Drawing.Point(12, 278);
            this.btnAzuriranjeGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAzuriranjeGume.Name = "btnAzuriranjeGume";
            this.btnAzuriranjeGume.Size = new System.Drawing.Size(845, 28);
            this.btnAzuriranjeGume.TabIndex = 10;
            this.btnAzuriranjeGume.Text = "Azurirajte gumu";
            this.btnAzuriranjeGume.UseVisualStyleBackColor = true;
            this.btnAzuriranjeGume.Click += new System.EventHandler(this.btnAzuriranjeGume_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 156);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Maksimalna brzina";
            // 
            // txtAzuriranjeDimenzije
            // 
            this.txtAzuriranjeDimenzije.Location = new System.Drawing.Point(8, 119);
            this.txtAzuriranjeDimenzije.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAzuriranjeDimenzije.Name = "txtAzuriranjeDimenzije";
            this.txtAzuriranjeDimenzije.Size = new System.Drawing.Size(848, 22);
            this.txtAzuriranjeDimenzije.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Dimenzije";
            // 
            // txtAzuriranjeProizvodjac
            // 
            this.txtAzuriranjeProizvodjac.Location = new System.Drawing.Point(8, 62);
            this.txtAzuriranjeProizvodjac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAzuriranjeProizvodjac.Name = "txtAzuriranjeProizvodjac";
            this.txtAzuriranjeProizvodjac.Size = new System.Drawing.Size(848, 22);
            this.txtAzuriranjeProizvodjac.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Proizvodjac";
            // 
            // dgvGume
            // 
            this.dgvGume.AllowUserToAddRows = false;
            this.dgvGume.AllowUserToDeleteRows = false;
            this.dgvGume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGume.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGume.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGume.Location = new System.Drawing.Point(21, 364);
            this.dgvGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGume.MultiSelect = false;
            this.dgvGume.Name = "dgvGume";
            this.dgvGume.ReadOnly = true;
            this.dgvGume.RowHeadersWidth = 51;
            this.dgvGume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGume.Size = new System.Drawing.Size(1753, 498);
            this.dgvGume.TabIndex = 1;
            this.dgvGume.SelectionChanged += new System.EventHandler(this.dgvGume_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericGumaMaxBrzina);
            this.groupBox1.Controls.Add(this.btnUnosGume);
            this.groupBox1.Controls.Add(this.cmbTipGume);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGumaDimenzije);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGumaProizvodjac);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(880, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unos nove gume";
            // 
            // numericGumaMaxBrzina
            // 
            this.numericGumaMaxBrzina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericGumaMaxBrzina.DecimalPlaces = 2;
            this.numericGumaMaxBrzina.Location = new System.Drawing.Point(8, 177);
            this.numericGumaMaxBrzina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericGumaMaxBrzina.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericGumaMaxBrzina.Name = "numericGumaMaxBrzina";
            this.numericGumaMaxBrzina.Size = new System.Drawing.Size(864, 22);
            this.numericGumaMaxBrzina.TabIndex = 11;
            // 
            // btnUnosGume
            // 
            this.btnUnosGume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnosGume.Location = new System.Drawing.Point(12, 278);
            this.btnUnosGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnosGume.Name = "btnUnosGume";
            this.btnUnosGume.Size = new System.Drawing.Size(860, 28);
            this.btnUnosGume.TabIndex = 10;
            this.btnUnosGume.Text = "Unesite novu gumu";
            this.btnUnosGume.UseVisualStyleBackColor = true;
            this.btnUnosGume.Click += new System.EventHandler(this.btnUnosGume_Click);
            // 
            // cmbTipGume
            // 
            this.cmbTipGume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipGume.FormattingEnabled = true;
            this.cmbTipGume.Location = new System.Drawing.Point(8, 231);
            this.cmbTipGume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipGume.Name = "cmbTipGume";
            this.cmbTipGume.Size = new System.Drawing.Size(863, 24);
            this.cmbTipGume.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tip gume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maksimalna brzina";
            // 
            // txtGumaDimenzije
            // 
            this.txtGumaDimenzije.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGumaDimenzije.Location = new System.Drawing.Point(8, 119);
            this.txtGumaDimenzije.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGumaDimenzije.Name = "txtGumaDimenzije";
            this.txtGumaDimenzije.Size = new System.Drawing.Size(863, 22);
            this.txtGumaDimenzije.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dimenzije";
            // 
            // txtGumaProizvodjac
            // 
            this.txtGumaProizvodjac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGumaProizvodjac.Location = new System.Drawing.Point(8, 62);
            this.txtGumaProizvodjac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGumaProizvodjac.Name = "txtGumaProizvodjac";
            this.txtGumaProizvodjac.Size = new System.Drawing.Size(863, 22);
            this.txtGumaProizvodjac.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proizvodjac";
            // 
            // tabPorucivanje
            // 
            this.tabPorucivanje.Location = new System.Drawing.Point(4, 25);
            this.tabPorucivanje.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPorucivanje.Name = "tabPorucivanje";
            this.tabPorucivanje.Size = new System.Drawing.Size(1784, 836);
            this.tabPorucivanje.TabIndex = 3;
            this.tabPorucivanje.Text = "Porucivanje robe";
            this.tabPorucivanje.UseVisualStyleBackColor = true;
            // 
            // tabKnjizenje
            // 
            this.tabKnjizenje.Location = new System.Drawing.Point(4, 25);
            this.tabKnjizenje.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabKnjizenje.Name = "tabKnjizenje";
            this.tabKnjizenje.Size = new System.Drawing.Size(1784, 836);
            this.tabKnjizenje.TabIndex = 4;
            this.tabKnjizenje.Text = "Knjizenje robe";
            this.tabKnjizenje.UseVisualStyleBackColor = true;
            // 
            // tabKorisnici
            // 
            this.tabKorisnici.Location = new System.Drawing.Point(4, 25);
            this.tabKorisnici.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabKorisnici.Name = "tabKorisnici";
            this.tabKorisnici.Size = new System.Drawing.Size(1784, 836);
            this.tabKorisnici.TabIndex = 5;
            this.tabKorisnici.Text = "Korisnici";
            this.tabKorisnici.UseVisualStyleBackColor = true;
            // 
            // pnlLoading
            // 
            this.pnlLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoading.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlLoading.Controls.Add(this.progressBarLoading);
            this.pnlLoading.Controls.Add(this.label4);
            this.pnlLoading.Location = new System.Drawing.Point(3, 2);
            this.pnlLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(1792, 865);
            this.pnlLoading.TabIndex = 1;
            this.pnlLoading.Visible = false;
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBarLoading.Location = new System.Drawing.Point(647, 436);
            this.progressBarLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(416, 28);
            this.progressBarLoading.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(663, 352);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 69);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ucitavanje...";
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.label12);
            this.pnlLogin.Controls.Add(this.label11);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Location = new System.Drawing.Point(3, 2);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(1805, 865);
            this.pnlLogin.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Location = new System.Drawing.Point(647, 425);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(437, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Ulogujte se";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(647, 351);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Lozinka";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(647, 273);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Korisnicko ime";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(647, 374);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(436, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Location = new System.Drawing.Point(647, 297);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(436, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Proizvodjac";
            // 
            // txtPretragaProizvodjac
            // 
            this.txtPretragaProizvodjac.Location = new System.Drawing.Point(226, 44);
            this.txtPretragaProizvodjac.Name = "txtPretragaProizvodjac";
            this.txtPretragaProizvodjac.Size = new System.Drawing.Size(162, 22);
            this.txtPretragaProizvodjac.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(436, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 17);
            this.label14.TabIndex = 3;
            this.label14.Text = "Tip gume";
            // 
            // cmbPretragaTipGume
            // 
            this.cmbPretragaTipGume.FormattingEnabled = true;
            this.cmbPretragaTipGume.Location = new System.Drawing.Point(439, 41);
            this.cmbPretragaTipGume.Name = "cmbPretragaTipGume";
            this.cmbPretragaTipGume.Size = new System.Drawing.Size(219, 24);
            this.cmbPretragaTipGume.TabIndex = 4;
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(712, 34);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(100, 31);
            this.btnPretraga.TabIndex = 5;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // dgvPretragaGume
            // 
            this.dgvPretragaGume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPretragaGume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPretragaGume.Location = new System.Drawing.Point(-1, 137);
            this.dgvPretragaGume.MultiSelect = false;
            this.dgvPretragaGume.Name = "dgvPretragaGume";
            this.dgvPretragaGume.RowHeadersWidth = 51;
            this.dgvPretragaGume.RowTemplate.Height = 24;
            this.dgvPretragaGume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPretragaGume.Size = new System.Drawing.Size(1179, 348);
            this.dgvPretragaGume.TabIndex = 1;
            // 
            // frmPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1799, 869);
            this.Controls.Add(this.tabCtr);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magacin auto guma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabCtr.ResumeLayout(false);
            this.ctxlogout.ResumeLayout(false);
            this.tabMagacin.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabGume.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAzuriranjeBrzina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGumaMaxBrzina)).EndInit();
            this.pnlLoading.ResumeLayout(false);
            this.pnlLoading.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPretragaGume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtr;
        private System.Windows.Forms.TabPage tabProdaja;
        private System.Windows.Forms.TabPage tabMagacin;
        private System.Windows.Forms.TabPage tabGume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericGumaMaxBrzina;
        private System.Windows.Forms.Button btnUnosGume;
        private System.Windows.Forms.ComboBox cmbTipGume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGumaDimenzije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGumaProizvodjac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPorucivanje;
        private System.Windows.Forms.TabPage tabKnjizenje;
        private System.Windows.Forms.TabPage tabKorisnici;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGume;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAzuriranjeId;
        private System.Windows.Forms.NumericUpDown numericAzuriranjeBrzina;
        private System.Windows.Forms.Button btnAzuriranjeGume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAzuriranjeDimenzije;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAzuriranjeProizvodjac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPretragaIDGume;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ContextMenuStrip ctxlogout;
        private System.Windows.Forms.ToolStripMenuItem izlogujteSeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPretragaProizvodjac;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPretragaTipGume;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvPretragaGume;
        private System.Windows.Forms.Button btnPretraga;
    }
}

