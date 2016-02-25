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
        public Form1()
        {
            InitializeComponent();

            CsvOlvaso o = new CsvOlvaso();
            List<Jarmu> jarmuvek = o.Beolvas("Gyakorlo_adatok.csv");
            JarmuAdatbazisKezelo ak = new JarmuAdatbazisKezelo();
            
            foreach (Jarmu jarmu in jarmuvek)
            {
                ak.Beszur(jarmu);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztos kilép a programból?", "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void jarmuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.jarmuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Jarmu' table. You can move, or remove it, as needed.
            this.jarmuTableAdapter.Fill(this.database1DataSet.Jarmu);

        }
    }
}
