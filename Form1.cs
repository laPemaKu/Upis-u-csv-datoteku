using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upisivanje_podataka_u_csv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            List<Osoba> listaosoba = new List<Osoba>();
            try
            {
                Osoba osoba = new Osoba(txtIme.Text, txtPrezime.Text, txtEmail.Text,Convert.ToInt16(txtGodRod.Text));
                txtIme.Clear();
                txtPrezime.Clear();
                txtEmail.Clear();
                txtGodRod.Clear();

                DialogResult upit = MessageBox.Show("Želite li unesti još podataka?", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (upit)
                {
                    case DialogResult.Yes:
                        {
                            listaosoba.Add(osoba);
                            break;
                        }
                    case DialogResult.No:
                        {
                            listaosoba.Add(osoba);
                            //upis podataka u datoteku
                            using (var writer = new StreamWriter("osobe.csv"))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                            {
                                csv.WriteRecords(listaosoba);
                            }

                            break;
                        }
                }

            }catch(Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogrešab unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
