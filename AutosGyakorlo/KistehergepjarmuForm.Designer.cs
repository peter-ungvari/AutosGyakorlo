namespace AutosGyakorlo
{
    partial class KistehergepjarmuForm
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
            this.jarmuControl = new AutosGyakorlo.JarmuControl();
            this.onsulyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kialakitasComboBox = new System.Windows.Forms.ComboBox();
            this.megsemButton = new System.Windows.Forms.Button();
            this.mentesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.onsulyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // jarmuControl
            // 
            this.jarmuControl.Location = new System.Drawing.Point(12, 12);
            this.jarmuControl.Name = "jarmuControl";
            this.jarmuControl.Size = new System.Drawing.Size(281, 211);
            this.jarmuControl.TabIndex = 0;
            // 
            // onsulyNumericUpDown
            // 
            this.onsulyNumericUpDown.Location = new System.Drawing.Point(131, 225);
            this.onsulyNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.onsulyNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.onsulyNumericUpDown.Name = "onsulyNumericUpDown";
            this.onsulyNumericUpDown.Size = new System.Drawing.Size(158, 20);
            this.onsulyNumericUpDown.TabIndex = 1;
            this.onsulyNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Önsúly";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kialakítás";
            // 
            // kialakitasComboBox
            // 
            this.kialakitasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kialakitasComboBox.FormattingEnabled = true;
            this.kialakitasComboBox.Items.AddRange(new object[] {
            "Ponyvás",
            "Szabadplatós",
            "Vontatós",
            "Zártterű"});
            this.kialakitasComboBox.Location = new System.Drawing.Point(131, 251);
            this.kialakitasComboBox.Name = "kialakitasComboBox";
            this.kialakitasComboBox.Size = new System.Drawing.Size(158, 21);
            this.kialakitasComboBox.TabIndex = 3;
            // 
            // megsemButton
            // 
            this.megsemButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megsemButton.Location = new System.Drawing.Point(214, 278);
            this.megsemButton.Name = "megsemButton";
            this.megsemButton.Size = new System.Drawing.Size(75, 23);
            this.megsemButton.TabIndex = 5;
            this.megsemButton.Text = "Mégsem";
            this.megsemButton.UseVisualStyleBackColor = true;
            this.megsemButton.Click += new System.EventHandler(this.megsemButton_Click);
            // 
            // mentesButton
            // 
            this.mentesButton.Location = new System.Drawing.Point(131, 278);
            this.mentesButton.Name = "mentesButton";
            this.mentesButton.Size = new System.Drawing.Size(75, 23);
            this.mentesButton.TabIndex = 6;
            this.mentesButton.Text = "Mentés";
            this.mentesButton.UseVisualStyleBackColor = true;
            this.mentesButton.Click += new System.EventHandler(this.mentesButton_Click);
            // 
            // KistehergepjarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 323);
            this.Controls.Add(this.megsemButton);
            this.Controls.Add(this.mentesButton);
            this.Controls.Add(this.kialakitasComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onsulyNumericUpDown);
            this.Controls.Add(this.jarmuControl);
            this.Name = "KistehergepjarmuForm";
            this.Text = "KistehergepjarmuForm";
            ((System.ComponentModel.ISupportInitialize)(this.onsulyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button megsemButton;
        private System.Windows.Forms.Button mentesButton;
        public JarmuControl jarmuControl;
        public System.Windows.Forms.NumericUpDown onsulyNumericUpDown;
        public System.Windows.Forms.ComboBox kialakitasComboBox;
    }
}