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
    public partial class KeresForm : Form
    {
        public KeresForm()
        {
            InitializeComponent();
        }

        List<Jarmu> jarmuvek;

        public List<Jarmu> Jarmuvek
        {
            get { return jarmuvek; }
            set { 
                jarmuvek = value;
                
                markaComboBox.Items.Add("Mind");
                markaComboBox.SelectedIndex = 0;
                
                // Minden jármuhoz a jarmuvek listában hozzárendeljük a markáját és így márkák listáját kapjuk.
                var markak = jarmuvek.Select(elem => elem.Marka);

                // A márkákat hozzáadjuk a comboboxhoz egyszerre.
                markaComboBox.Items.AddRange(markak.ToArray());

                Frissit();
            }
        }

        private void markaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void ArMinNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void arMaxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void rendszamTextBox_TextChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void Frissit()
        {
            // A jarmuvek listának minden j elemét megvizsgáljuk, hogy igazak-e rá a feltételek. Amikre igaz, az kerül a szurtbe.
            var szurt = jarmuvek.Where(j =>
                j.Rendszam.Contains(rendszamTextBox.Text)
                && j.Ar() >= (long)ArMinNumericUpDown.Value
                && j.Ar() <= (long)arMaxNumericUpDown.Value
                && (markaComboBox.SelectedIndex == 0 || j.Marka.Equals(markaComboBox.SelectedItem)));

            if (szurt.Any()) {
                jarmuListBox.DataSource = new List<Jarmu>(szurt);
            }
            else
            {
                jarmuListBox.DataSource = null;
            }
            
        }
    }
}
