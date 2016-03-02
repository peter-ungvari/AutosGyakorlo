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
        AdatbazisKezelo<SzemelyGepjarmu> szAbk = AdatbazisKezeloGyarto.UjSzemelygepjarmuAbk();
        AdatbazisKezelo<KisteherGepjarmu> kAbk = AdatbazisKezeloGyarto.UjKisteherGepjarmuAbk();

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
                if (jarmu is SzemelyGepjarmu)
                {
                    szAbk.Beszur(jarmu as SzemelyGepjarmu);
                }
                else
                {
                    kAbk.Beszur(jarmu as KisteherGepjarmu);
                }
            }

            Frissit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fajtaComboBox.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frissit();
        }

        private void Frissit()
        {
            if (fajtaComboBox.SelectedIndex == 0)
            {
                jarmuListBox.DataSource = szAbk.Listaz();
            }
            else
            {
                jarmuListBox.DataSource = kAbk.Listaz();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (jarmuListBox.SelectedItem is SzemelyGepjarmu)
            {
                SzemelyGepjarmu sz = jarmuListBox.SelectedItem as SzemelyGepjarmu;
                szAbk.Torol(sz);
            }
            else if (jarmuListBox.SelectedItem is KisteherGepjarmu)
            {
                KisteherGepjarmu k = jarmuListBox.SelectedItem as KisteherGepjarmu;
                kAbk.Torol(k);
            }

            Frissit();

            bool enabled = jarmuListBox.SelectedItem != null;
            deleteButton.Enabled = enabled;
            szerkesztButton.Enabled = enabled;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (jarmuListBox.SelectedItem != null)
            {
                Jarmu jarmu = jarmuListBox.SelectedItem as Jarmu;
                MessageBox.Show(this, String.Format("Ár: {0}", jarmu.Ar()), String.Format("{0} {1}", jarmu.Marka, jarmu.Tipus),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ujSzemelygepjarmuButton_Click(object sender, EventArgs e)
        {
            SzemelyGepjarmuForm form = new SzemelyGepjarmuForm();
            form.Text = "Új személygépjármű";

            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                SzemelyGepjarmu sz = new SzemelyGepjarmu();
                JarmuAdatokFormbol(sz, form.jarmuControl);

                sz.Hangrendszer = form.hangrendszerCheckBox.Checked;
                sz.Felszereltseg = (Felszereltseg)form.felszereltsegComboBox.SelectedIndex;

                szAbk.Beszur(sz);

                if (fajtaComboBox.SelectedIndex == 1)
                {
                    fajtaComboBox.SelectedIndex = 0;
                }
                else
                {
                    Frissit();
                }
            }
        }

        private void ujKistehergepjarmuButton_Click(object sender, EventArgs e)
        {
            KistehergepjarmuForm form = new KistehergepjarmuForm();
            form.Text = "Új kistehergépjármű";

            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                KisteherGepjarmu k = new KisteherGepjarmu();
                JarmuAdatokFormbol(k, form.jarmuControl);

                k.Onsuly = (int)form.onsulyNumericUpDown.Value;
                k.Kialakitas = (Kialakitas)form.kialakitasComboBox.SelectedIndex;

                kAbk.Beszur(k);

                if (fajtaComboBox.SelectedIndex == 0)
                {
                    fajtaComboBox.SelectedIndex = 1;
                }
                else
                {
                    Frissit();
                }
            }
        }

        private void JarmuAdatokFormbol(Jarmu jarmu, JarmuControl jarmuControl)
        {
            jarmu.Marka = jarmuControl.markaTextBox.Text;
            jarmu.Tipus = jarmuControl.tipusTextBox.Text;
            jarmu.FutottKm = (int)jarmuControl.kmNumericUpDown.Value;
            jarmu.Hengerurt = (int)jarmuControl.hengerUrtNumericUpDown.Value;
            jarmu.Rendszam = jarmuControl.rendszamTextBox.Text;
            jarmu.Alvazszam = jarmuControl.alvazszamTextBox.Text;
            jarmu.SzallithatoSzemelyek = (int)jarmuControl.szemelyekNumericUpDown.Value;
            jarmu.HasznosTeher = (int)jarmuControl.hasznosTeherNumericUpDown.Value;
        }

        private void JarmuAdatokFormba(Jarmu jarmu, JarmuControl jarmuControl)
        {
            jarmuControl.markaTextBox.Text = jarmu.Marka;
            jarmuControl.tipusTextBox.Text = jarmu.Tipus;
            jarmuControl.kmNumericUpDown.Value = jarmu.FutottKm;
            jarmuControl.hengerUrtNumericUpDown.Value = jarmu.Hengerurt;
            jarmuControl.rendszamTextBox.Text = jarmu.Rendszam;
            jarmuControl.alvazszamTextBox.Text = jarmu.Alvazszam;
            jarmuControl.szemelyekNumericUpDown.Value = jarmu.SzallithatoSzemelyek;
            jarmuControl.hasznosTeherNumericUpDown.Value = jarmu.HasznosTeher;
        }

        private void szerkesztButton_Click(object sender, EventArgs e)
        {

            if (jarmuListBox.SelectedItem is SzemelyGepjarmu)
            {
                SzemelyGepjarmu sz = jarmuListBox.SelectedItem as SzemelyGepjarmu;

                SzemelyGepjarmuForm form = new SzemelyGepjarmuForm();
                form.Text = "Személygépjármű módosítása";
                JarmuAdatokFormba(sz, form.jarmuControl);
                form.hangrendszerCheckBox.Checked = sz.Hangrendszer;
                form.felszereltsegComboBox.SelectedIndex = (int)sz.Felszereltseg;
                DialogResult dr = form.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    JarmuAdatokFormbol(sz, form.jarmuControl);

                    sz.Hangrendszer = form.hangrendszerCheckBox.Checked;
                    sz.Felszereltseg = (Felszereltseg)form.felszereltsegComboBox.SelectedIndex;

                    szAbk.Modosit(sz);

                    if (fajtaComboBox.SelectedIndex == 1)
                    {
                        fajtaComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        Frissit();
                    }
                }
            }
            else
            {
                KisteherGepjarmu k = jarmuListBox.SelectedItem as KisteherGepjarmu;
                KistehergepjarmuForm form = new KistehergepjarmuForm();

                form.Text = "Kistehergépjármű módosítása";
                JarmuAdatokFormba(k, form.jarmuControl);
                form.onsulyNumericUpDown.Value = k.Onsuly;
                form.kialakitasComboBox.SelectedIndex = (int)k.Kialakitas;
                DialogResult dr = form.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    JarmuAdatokFormbol(k, form.jarmuControl);

                    k.Onsuly = (int)form.onsulyNumericUpDown.Value;
                    k.Kialakitas = (Kialakitas)form.kialakitasComboBox.SelectedIndex;

                    kAbk.Modosit(k);

                    if (fajtaComboBox.SelectedIndex == 0)
                    {
                        fajtaComboBox.SelectedIndex = 1;
                    }
                    else
                    {
                        Frissit();
                    }
                }
            }

        }

        private void jarmuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled = jarmuListBox.SelectedItem != null;
            deleteButton.Enabled = enabled;
            szerkesztButton.Enabled = enabled;
        }

        private void KeresButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parameterek = new Dictionary<string, object>();
            parameterek.Add("@min", (int)kmMinNumericUpDown.Value);
            parameterek.Add("@max", (int)kmMaxNumericUpDown.Value);
            List<Jarmu> jarmuvek = new List<Jarmu>(szAbk.Keres(
                    @"select *
                    from jarmu j
                    join szemelygepjarmu sz on j.alvazszam = sz.alvazszam
                    where futottKm between @min and @max", parameterek));
            jarmuvek.AddRange(kAbk.Keres(
                    @"select *
                    from jarmu j
                    join kistehergepjarmu k on j.alvazszam = k.alvazszam
                    where futottKm between @min and @max", parameterek));

            if (jarmuvek.Count == 0)
            {
                MessageBox.Show(this, "Nincs a keresésnek megfelelő jármű", "Keresés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KeresForm keresForm = new KeresForm();
                keresForm.Jarmuvek = jarmuvek;
                keresForm.ShowDialog(this);
            }
        }

    }
}
