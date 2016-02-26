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
    public partial class JarmuForm : Form
    {
        JarmuAdatbazisKezelo ak = new JarmuAdatbazisKezelo();

        public JarmuForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztos kilép a programból?", "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CsvOlvaso o = new CsvOlvaso();
            List<Jarmu> jarmuvek = o.Beolvas("Gyakorlo_adatok.csv");
            

            foreach (Jarmu jarmu in jarmuvek)
            {
                ak.Beszur(jarmu);
            }

            Frissit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void Frissit()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listBox1.DataSource = ak.SzemelyGepjarmuListaz();
            }
            else
            {
                listBox1.DataSource = ak.KisteherGepjarmuListaz();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is SzemelyGepjarmu)
            {
                SzemelyGepjarmu sz = listBox1.SelectedItem as SzemelyGepjarmu;
                ak.Torol(sz);
            }
            else if (listBox1.SelectedItem is KisteherGepjarmu)
            {
                KisteherGepjarmu k = listBox1.SelectedItem as KisteherGepjarmu;
                ak.Torol(k);
            }

            Frissit();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Jarmu jarmu = listBox1.SelectedItem as Jarmu;
                MessageBox.Show(this, String.Format("Ár: {0}", jarmu.Ar()), String.Format("{0} {1}", jarmu.Marka, jarmu.Tipus), 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
