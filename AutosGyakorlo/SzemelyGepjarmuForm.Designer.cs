namespace AutosGyakorlo
{
    partial class SzemelyGepjarmuForm
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
            this.hangrendszerCheckBox = new System.Windows.Forms.CheckBox();
            this.felszereltsegComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mentesButton = new System.Windows.Forms.Button();
            this.megsemButton = new System.Windows.Forms.Button();
            this.jarmuControl = new AutosGyakorlo.JarmuControl();
            this.SuspendLayout();
            // 
            // HangrendszerCheckBox
            // 
            this.hangrendszerCheckBox.AutoSize = true;
            this.hangrendszerCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.hangrendszerCheckBox.Location = new System.Drawing.Point(132, 229);
            this.hangrendszerCheckBox.Name = "HangrendszerCheckBox";
            this.hangrendszerCheckBox.Size = new System.Drawing.Size(160, 17);
            this.hangrendszerCheckBox.TabIndex = 1;
            this.hangrendszerCheckBox.Text = "Hangrendszerrel rendelkezik";
            this.hangrendszerCheckBox.UseVisualStyleBackColor = true;
            // 
            // felszereltsegComboBox
            // 
            this.felszereltsegComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.felszereltsegComboBox.FormattingEnabled = true;
            this.felszereltsegComboBox.Items.AddRange(new object[] {
            "Alap",
            "Közepes",
            "Magas"});
            this.felszereltsegComboBox.Location = new System.Drawing.Point(132, 252);
            this.felszereltsegComboBox.Name = "felszereltsegComboBox";
            this.felszereltsegComboBox.Size = new System.Drawing.Size(160, 21);
            this.felszereltsegComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Felszereltség";
            // 
            // mentesButton
            // 
            this.mentesButton.Location = new System.Drawing.Point(132, 279);
            this.mentesButton.Name = "mentesButton";
            this.mentesButton.Size = new System.Drawing.Size(75, 23);
            this.mentesButton.TabIndex = 4;
            this.mentesButton.Text = "Mentés";
            this.mentesButton.UseVisualStyleBackColor = true;
            this.mentesButton.Click += new System.EventHandler(this.mentesButton_Click);
            // 
            // megsemButton
            // 
            this.megsemButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megsemButton.Location = new System.Drawing.Point(217, 279);
            this.megsemButton.Name = "megsemButton";
            this.megsemButton.Size = new System.Drawing.Size(75, 23);
            this.megsemButton.TabIndex = 4;
            this.megsemButton.Text = "Mégsem";
            this.megsemButton.UseVisualStyleBackColor = true;
            this.megsemButton.Click += new System.EventHandler(this.megsemButton_Click);
            // 
            // jarmuControl
            // 
            this.jarmuControl.Location = new System.Drawing.Point(12, 12);
            this.jarmuControl.Name = "jarmuControl";
            this.jarmuControl.Size = new System.Drawing.Size(283, 211);
            this.jarmuControl.TabIndex = 0;
            // 
            // SzemelyGepjarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 327);
            this.Controls.Add(this.megsemButton);
            this.Controls.Add(this.mentesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.felszereltsegComboBox);
            this.Controls.Add(this.hangrendszerCheckBox);
            this.Controls.Add(this.jarmuControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SzemelyGepjarmuForm";
            this.Load += new System.EventHandler(this.GepjarmuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mentesButton;
        private System.Windows.Forms.Button megsemButton;
        public JarmuControl jarmuControl;
        public System.Windows.Forms.CheckBox hangrendszerCheckBox;
        public System.Windows.Forms.ComboBox felszereltsegComboBox;



    }
}