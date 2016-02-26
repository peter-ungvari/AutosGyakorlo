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
    public partial class Form1 : Form
    {
        JarmuAdatbazisKezelo ak = new JarmuAdatbazisKezelo();

        public Form1()
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

            listBox1.DataSource = ak.KisteherGepjarmuListaz();
            listBox2.DataSource = ak.SzemelyGepjarmuListaz();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(ak.KisteherGepjarmuListaz().ToArray());
            listBox2.Items.AddRange(ak.SzemelyGepjarmuListaz().ToArray());
        }

    }
}
