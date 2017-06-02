namespace Trial2
{
    partial class StyleSelector
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
            this.label13 = new System.Windows.Forms.Label();
            this.CoatStyleCB = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PantStyleCB = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ShirtStyleCB = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SLStyleCB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.VestStyleCB = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TieColorCB = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TieStyleCB = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.PocketSquareStyleCB = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.VestColorCB = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ShoeStyleCB = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SpecialTB = new System.Windows.Forms.TextBox();
            this.SaveStylesBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            //this.masterTrial = new Trial2.MasterTrial();
            this.masterStyleListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.masterStyleListTableAdapter = new Trial2.MasterTrialTableAdapters.MasterStyleListTableAdapter();
            //((System.ComponentModel.ISupportInitialize)(this.masterTrial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterStyleListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Coat Style";
            // 
            // CoatStyleCB
            // 
            this.CoatStyleCB.DataSource = this.masterStyleListBindingSource;
            this.CoatStyleCB.DisplayMember = "CoatStyle";
            this.CoatStyleCB.FormattingEnabled = true;
            this.CoatStyleCB.Location = new System.Drawing.Point(99, 9);
            this.CoatStyleCB.Name = "CoatStyleCB";
            this.CoatStyleCB.Size = new System.Drawing.Size(121, 21);
            this.CoatStyleCB.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Pant Style";
            // 
            // PantStyleCB
            // 
            this.PantStyleCB.FormattingEnabled = true;
            this.PantStyleCB.Location = new System.Drawing.Point(99, 36);
            this.PantStyleCB.Name = "PantStyleCB";
            this.PantStyleCB.Size = new System.Drawing.Size(121, 21);
            this.PantStyleCB.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Shirt Style";
            // 
            // ShirtStyleCB
            // 
            this.ShirtStyleCB.FormattingEnabled = true;
            this.ShirtStyleCB.Location = new System.Drawing.Point(99, 63);
            this.ShirtStyleCB.Name = "ShirtStyleCB";
            this.ShirtStyleCB.Size = new System.Drawing.Size(121, 21);
            this.ShirtStyleCB.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "S + L Style";
            // 
            // SLStyleCB
            // 
            this.SLStyleCB.FormattingEnabled = true;
            this.SLStyleCB.Location = new System.Drawing.Point(99, 90);
            this.SLStyleCB.Name = "SLStyleCB";
            this.SLStyleCB.Size = new System.Drawing.Size(121, 21);
            this.SLStyleCB.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Vest Style";
            // 
            // VestStyleCB
            // 
            this.VestStyleCB.FormattingEnabled = true;
            this.VestStyleCB.Location = new System.Drawing.Point(99, 117);
            this.VestStyleCB.Name = "VestStyleCB";
            this.VestStyleCB.Size = new System.Drawing.Size(121, 21);
            this.VestStyleCB.TabIndex = 33;
            this.VestStyleCB.SelectedIndexChanged += new System.EventHandler(this.VestStyleCB_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(226, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Vest Color";
            // 
            // TieColorCB
            // 
            this.TieColorCB.FormattingEnabled = true;
            this.TieColorCB.Location = new System.Drawing.Point(297, 144);
            this.TieColorCB.Name = "TieColorCB";
            this.TieColorCB.Size = new System.Drawing.Size(121, 21);
            this.TieColorCB.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 144);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "Tie Style";
            // 
            // TieStyleCB
            // 
            this.TieStyleCB.FormattingEnabled = true;
            this.TieStyleCB.Location = new System.Drawing.Point(99, 144);
            this.TieStyleCB.Name = "TieStyleCB";
            this.TieStyleCB.Size = new System.Drawing.Size(121, 21);
            this.TieStyleCB.TabIndex = 37;
            this.TieStyleCB.SelectedIndexChanged += new System.EventHandler(this.TieStyleCB_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(226, 144);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Tie Color";
            // 
            // PocketSquareStyleCB
            // 
            this.PocketSquareStyleCB.FormattingEnabled = true;
            this.PocketSquareStyleCB.Location = new System.Drawing.Point(200, 208);
            this.PocketSquareStyleCB.Name = "PocketSquareStyleCB";
            this.PocketSquareStyleCB.Size = new System.Drawing.Size(121, 21);
            this.PocketSquareStyleCB.TabIndex = 39;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(89, 208);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Pocket Square Color";
            // 
            // VestColorCB
            // 
            this.VestColorCB.FormattingEnabled = true;
            this.VestColorCB.Location = new System.Drawing.Point(297, 117);
            this.VestColorCB.Name = "VestColorCB";
            this.VestColorCB.Size = new System.Drawing.Size(121, 21);
            this.VestColorCB.TabIndex = 41;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(89, 184);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "Shoe Style + Color";
            // 
            // ShoeStyleCB
            // 
            this.ShoeStyleCB.FormattingEnabled = true;
            this.ShoeStyleCB.Location = new System.Drawing.Point(200, 181);
            this.ShoeStyleCB.Name = "ShoeStyleCB";
            this.ShoeStyleCB.Size = new System.Drawing.Size(121, 21);
            this.ShoeStyleCB.TabIndex = 43;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(89, 235);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 13);
            this.label23.TabIndex = 44;
            this.label23.Text = "Special Intructions";
            // 
            // SpecialTB
            // 
            this.SpecialTB.Location = new System.Drawing.Point(200, 235);
            this.SpecialTB.Name = "SpecialTB";
            this.SpecialTB.Size = new System.Drawing.Size(100, 20);
            this.SpecialTB.TabIndex = 45;
            // 
            // SaveStylesBTN
            // 
            this.SaveStylesBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveStylesBTN.Location = new System.Drawing.Point(92, 280);
            this.SaveStylesBTN.Name = "SaveStylesBTN";
            this.SaveStylesBTN.Size = new System.Drawing.Size(75, 23);
            this.SaveStylesBTN.TabIndex = 46;
            this.SaveStylesBTN.Text = "Save Styles";
            this.SaveStylesBTN.UseVisualStyleBackColor = true;
            this.SaveStylesBTN.Click += new System.EventHandler(this.SaveStylesBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(173, 280);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 47;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // masterTrial
            // 
            //this.masterTrial.DataSetName = "MasterTrial";
            //this.masterTrial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // masterStyleListBindingSource
            // 
            this.masterStyleListBindingSource.DataMember = "MasterStyleList";
            //this.masterStyleListBindingSource.DataSource = this.masterTrial;
            // 
            // masterStyleListTableAdapter
            // 
            //this.masterStyleListTableAdapter.ClearBeforeFill = true;
            // 
            // StyleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 330);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.SaveStylesBTN);
            this.Controls.Add(this.SpecialTB);
            this.Controls.Add(this.ShirtStyleCB);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ShoeStyleCB);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.VestColorCB);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.PocketSquareStyleCB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TieStyleCB);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TieColorCB);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.VestStyleCB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.SLStyleCB);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.PantStyleCB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CoatStyleCB);
            this.Controls.Add(this.label13);
            this.Name = "StyleSelector";
            this.Text = "Style Selector";
            this.Load += new System.EventHandler(this.StyleSelector_Load);
            //((System.ComponentModel.ISupportInitialize)(this.masterTrial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterStyleListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CoatStyleCB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox PantStyleCB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ShirtStyleCB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox SLStyleCB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox VestStyleCB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox TieColorCB;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox TieStyleCB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox PocketSquareStyleCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox VestColorCB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ShoeStyleCB;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox SpecialTB;
        private System.Windows.Forms.Button SaveStylesBTN;
        private System.Windows.Forms.Button CancelBTN;
        //private MasterTrial masterTrial;
        private System.Windows.Forms.BindingSource masterStyleListBindingSource;
        //private MasterTrialTableAdapters.MasterStyleListTableAdapter masterStyleListTableAdapter;
    }
}