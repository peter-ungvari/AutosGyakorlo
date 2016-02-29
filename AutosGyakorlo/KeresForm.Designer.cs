namespace AutosGyakorlo
{
    partial class KeresForm
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
            this.jarmuListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.markaComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.arMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rendszamTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arMaxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // jarmuListBox
            // 
            this.jarmuListBox.FormattingEnabled = true;
            this.jarmuListBox.HorizontalScrollbar = true;
            this.jarmuListBox.Location = new System.Drawing.Point(12, 126);
            this.jarmuListBox.Name = "jarmuListBox";
            this.jarmuListBox.Size = new System.Drawing.Size(1112, 147);
            this.jarmuListBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rendszamTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.arMaxNumericUpDown);
            this.groupBox1.Controls.Add(this.ArMinNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.markaComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Szűrés";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Márka";
            // 
            // markaComboBox
            // 
            this.markaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.markaComboBox.FormattingEnabled = true;
            this.markaComboBox.Location = new System.Drawing.Point(85, 19);
            this.markaComboBox.Name = "markaComboBox";
            this.markaComboBox.Size = new System.Drawing.Size(262, 21);
            this.markaComboBox.TabIndex = 1;
            this.markaComboBox.SelectedIndexChanged += new System.EventHandler(this.markaComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rendszám";
            // 
            // ArMinNumericUpDown
            // 
            this.ArMinNumericUpDown.Location = new System.Drawing.Point(85, 46);
            this.ArMinNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ArMinNumericUpDown.Name = "ArMinNumericUpDown";
            this.ArMinNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ArMinNumericUpDown.TabIndex = 3;
            this.ArMinNumericUpDown.ValueChanged += new System.EventHandler(this.ArMinNumericUpDown_ValueChanged);
            // 
            // arMaxNumericUpDown
            // 
            this.arMaxNumericUpDown.Location = new System.Drawing.Point(227, 46);
            this.arMaxNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.arMaxNumericUpDown.Name = "arMaxNumericUpDown";
            this.arMaxNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.arMaxNumericUpDown.TabIndex = 3;
            this.arMaxNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.arMaxNumericUpDown.ValueChanged += new System.EventHandler(this.arMaxNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ár";
            // 
            // rendszamTextBox
            // 
            this.rendszamTextBox.Location = new System.Drawing.Point(86, 73);
            this.rendszamTextBox.Name = "rendszamTextBox";
            this.rendszamTextBox.Size = new System.Drawing.Size(261, 20);
            this.rendszamTextBox.TabIndex = 5;
            this.rendszamTextBox.TextChanged += new System.EventHandler(this.rendszamTextBox_TextChanged);
            // 
            // KeresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 288);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.jarmuListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "KeresForm";
            this.Text = "KeresForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arMaxNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox jarmuListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rendszamTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown arMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown ArMinNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox markaComboBox;
        private System.Windows.Forms.Label label1;
    }
}