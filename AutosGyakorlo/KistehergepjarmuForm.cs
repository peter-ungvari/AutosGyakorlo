using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutosGyakorlo
{
    public partial class KistehergepjarmuForm : Form
    {
        public KistehergepjarmuForm()
        {
            InitializeComponent();

            kialakitasComboBox.SelectedIndex = 0;
        }

        private void megsemButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            bool ervenyes = !string.IsNullOrEmpty(jarmuControl.markaTextBox.Text)
                && !string.IsNullOrEmpty(jarmuControl.tipusTextBox.Text)
                && !string.IsNullOrEmpty(jarmuControl.rendszamTextBox.Text)
                && !string.IsNullOrEmpty(jarmuControl.alvazszamTextBox.Text);

            if (ervenyes)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Kérem töltsön ki minden mezőt a mentéshez.");
            }
        }
    }
}
