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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        static string constring = "Data Source = KROANKE; Initial Catalog = taksitDatabase; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);


        static int index;
        static string borc;
        static string taksit;

        

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    
                    string get = "SELECT * FROM taksitlendirme WHERE OgrenciID =  " +  textBox1.Text + " AND TaksitOdemeDurumu = 0" ;
                   
                    
                    SqlCommand getCommand = new SqlCommand(get, connect);
                    

                    
                    SqlDataReader dataReader = getCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        /* Update taksitlendirme set taksitodemedurumu  = 1 where ogrenciId .... TaksitNo = (secilen index) */
                        checkedListBox1.Items.Add(dataReader.GetValue(2) + ". Taksit");
                        
                    }


                    connect.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string update = "UPDATE taksitlendirme SET TaksitOdemeDurumu = 1 WHERE OgrenciID = " + textBox1.Text + " AND TaksitNo = " + index;

            SqlCommand updateCommand;

            try
            {
                checkedListBox1.Items.Clear();
                connect.Open();
                updateCommand = new SqlCommand(update, connect);
               /* SqlDataAdapter sqlDataAdap = new SqlDataAdapter(updateCommand);*/

                updateCommand.ExecuteNonQuery();

                updateCommand.Dispose();
                
                MessageBox.Show("Taksit Odendi");



                string get = "SELECT * FROM taksitlendirme WHERE OgrenciID =  " + textBox1.Text + " AND TaksitOdemeDurumu = 0";

                
                SqlCommand getCommand = new SqlCommand(get, connect);
                
                SqlDataReader dataReader = getCommand.ExecuteReader();

                
                while (dataReader.Read())
                {
                    /* Update taksitlendirme set taksitodemedurumu  = 1 where ogrenciId .... TaksitNo = (secilen index) */
                    checkedListBox1.Items.Add(dataReader.GetValue(2) + ". Taksit");

                }
                dataReader.Close();
                

                string getTaksitMiktari = "SELECT TaksitMiktar FROM taksitlendirme WHERE OgrenciID = " + textBox1.Text;
                SqlCommand getTaksitMiktar = new SqlCommand(getTaksitMiktari, connect);

                /*SqlDataReader taksitReader = getTaksitMiktar.ExecuteReader();*/
                dataReader = getTaksitMiktar.ExecuteReader();
                //Kac TL odendigi
                while (dataReader.Read())
                {
                    
                    taksit = dataReader.GetValue(0).ToString();
                    
                }
                

                dataReader.Close();

                //Kac TL kaldigi
                string getKalanBorc = "SELECT SUM(TaksitMiktar) FROM taksitlendirme WHERE OgrenciId = " + textBox1.Text + " AND TaksitOdemeDurumu = 0";

                SqlCommand kalanBorc = new SqlCommand(getKalanBorc, connect);
                dataReader = kalanBorc.ExecuteReader();

                while (dataReader.Read())
                {
                    borc = dataReader.GetValue(0).ToString();
                }

                
                dataReader.Close();

                MessageBox.Show(index + ". Taksit Odendi\n" + taksit + "TL odendi\n" + "Kalan Borc: " + borc);

                dataReader.Close();



                connect.Close();




                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*checkedTaksit = checkedListBox1.Items[e.Index].ToString();*/
            string selected = (sender as CheckedListBox).SelectedItem.ToString();
            char[] firstLetter = selected.ToCharArray();
            index = int.Parse(firstLetter[0].ToString());
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(index, borc, taksit);
            this.Hide();
            form3.ShowDialog();
        }
    }
}
