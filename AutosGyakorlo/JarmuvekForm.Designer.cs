namespace AutosGyakorlo
{
    partial class JarmuForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.jarmuListBox = new System.Windows.Forms.ListBox();
            this.fajtaComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KeresButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ujSzemelygepjarmuButton = new System.Windows.Forms.Button();
            this.ujKistehergepjarmuButton = new System.Windows.Forms.Button();
            this.szerkesztButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Importál CSV-ből az adatbázisba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // jarmuListBox
            // 
            this.jarmuListBox.FormattingEnabled = true;
            this.jarmuListBox.HorizontalScrollbar = true;
            this.jarmuListBox.Location = new System.Drawing.Point(12, 85);
            this.jarmuListBox.Name = "jarmuListBox";
            this.jarmuListBox.Size = new System.Drawing.Size(1112, 316);
            this.jarmuListBox.TabIndex = 1;
            this.jarmuListBox.SelectedIndexChanged += new System.EventHandler(this.jarmuListBox_SelectedIndexChanged);
            this.jarmuListBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // fajtaComboBox
            // 
            this.fajtaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fajtaComboBox.FormattingEnabled = true;
            this.fajtaComboBox.Items.AddRange(new object[] {
            "Személygépjármű",
            "Kisteher gépjármű"});
            this.fajtaComboBox.Location = new System.Drawing.Point(12, 58);
            this.fajtaComboBox.Name = "fajtaComboBox";
            this.fajtaComboBox.Size = new System.Drawing.Size(158, 21);
            this.fajtaComboBox.TabIndex = 2;
            this.fajtaComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(234, 56);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Töröl";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Futott Kilométer";
            // 
            // KeresButton
            // 
            this.KeresButton.Location = new System.Drawing.Point(1049, 56);
            this.KeresButton.Name = "KeresButton";
            this.KeresButton.Size = new System.Drawing.Size(75, 23);
            this.KeresButton.TabIndex = 6;
            this.KeresButton.Text = "Keres";
            this.KeresButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(915, 59);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(128, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ujSzemelygepjarmuButton
            // 
            this.ujSzemelygepjarmuButton.Location = new System.Drawing.Point(315, 56);
            this.ujSzemelygepjarmuButton.Name = "ujSzemelygepjarmuButton";
            this.ujSzemelygepjarmuButton.Size = new System.Drawing.Size(120, 23);
            this.ujSzemelygepjarmuButton.TabIndex = 3;
            this.ujSzemelygepjarmuButton.Text = "Új személygépjármű";
            this.ujSzemelygepjarmuButton.UseVisualStyleBackColor = true;
            this.ujSzemelygepjarmuButton.Click += new System.EventHandler(this.ujSzemelygepjarmuButton_Click);
            // 
            // ujKistehergepjarmuButton
            // 
            this.ujKistehergepjarmuButton.Location = new System.Drawing.Point(441, 56);
            this.ujKistehergepjarmuButton.Name = "ujKistehergepjarmuButton";
            this.ujKistehergepjarmuButton.Size = new System.Drawing.Size(120, 23);
            this.ujKistehergepjarmuButton.TabIndex = 3;
            this.ujKistehergepjarmuButton.Text = "Új kistehergépjármű";
            this.ujKistehergepjarmuButton.UseVisualStyleBackColor = true;
            this.ujKistehergepjarmuButton.Click += new System.EventHandler(this.ujKistehergepjarmuButton_Click);
            // 
            // szerkesztButton
            // 
            this.szerkesztButton.Enabled = false;
            this.szerkesztButton.Location = new System.Drawing.Point(567, 56);
            this.szerkesztButton.Name = "szerkesztButton";
            this.szerkesztButton.Size = new System.Drawing.Size(75, 23);
            this.szerkesztButton.TabIndex = 8;
            this.szerkesztButton.Text = "Szerkeszt";
            this.szerkesztButton.UseVisualStyleBackColor = true;
            this.szerkesztButton.Click += new System.EventHandler(this.szerkesztButton_Click);
            // 
            // JarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 410);
            this.Controls.Add(this.szerkesztButton);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.KeresButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ujKistehergepjarmuButton);
            this.Controls.Add(this.ujSzemelygepjarmuButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.fajtaComboBox);
            this.Controls.Add(this.jarmuListBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "JarmuForm";
            this.Text = "Járművek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox jarmuListBox;
        private System.Windows.Forms.ComboBox fajtaComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button KeresButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button ujSzemelygepjarmuButton;
        private System.Windows.Forms.Button ujKistehergepjarmuButton;
        private System.Windows.Forms.Button szerkesztButton;


    }
}

