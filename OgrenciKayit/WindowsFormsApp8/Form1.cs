using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ogrIsimSoyad;
        string adres;

        string anneIsimSoyad;
        string anneTC;

        string babaIsimSoyad;
        string babaTC;
        string babaTelefon;

        public int taksitMiktari;

        //SQL connection
        static string constring = "Data Source = KROANKE; Initial Catalog = taksitDatabase; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        private void Form1_Load(object sender, EventArgs e)
        {

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();

                    int i;
                    string kayit = "INSERT INTO taksitlendirme (OgrenciID,TaksitNo,TaksitMiktar,TaksitTarihi,TaksitOdemeDurumu) VALUES (@OgrenciID,@TaksitNo,@TaksitMiktar,@TaksitTarihi,@TaksitOdemeDurumu)";
                    SqlCommand command = new SqlCommand(kayit, connect);
                    int month = 0;
                    if (!String.IsNullOrEmpty(textBox9.Text) && !String.IsNullOrEmpty(textBox10.Text) && !String.IsNullOrEmpty(textBox11.Text))
                    {
                        for (i = 1; i < Int32.Parse(textBox10.Text) + 1; i++)
                        {
                            command.Parameters.Clear();

                            command.Parameters.AddWithValue("@OgrenciID", textBox9.Text);
                            /*command.Parameters.AddWithValue("@TaksitId", i);*/
                            command.Parameters.AddWithValue("@TaksitNo", i);
                            int taksitMiktari = Int32.Parse(textBox11.Text) / Int32.Parse(textBox10.Text);
                            command.Parameters.AddWithValue("@TaksitMiktar", taksitMiktari);

                            DateTime thisDay = DateTime.Today;

                            command.Parameters.AddWithValue("@TaksitTarihi", thisDay.AddMonths(month).ToString("d"));
                            command.Parameters.AddWithValue("@TaksitOdemeDurumu", 0);

                            command.ExecuteNonQuery();
                            /*                        connect.Close();
                            */
                            month++;
                        }
                        MessageBox.Show("Kayit Eklendi");
                    }
                    else
                    {
                        MessageBox.Show("Lutfen * olan yerleri doldurunuz.");
                    }
                    

                    connect.Close(); // sikinti cikarsa burayi sil

                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            
        }

        
    }
}
