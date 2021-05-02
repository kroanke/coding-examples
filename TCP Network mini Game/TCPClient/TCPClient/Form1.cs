using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTcp;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;

        string last_word;
        char last_letter;
        char before_last_letter;
        char first_letter;
        char after_first_letter;

        int timer = 10;
        int turn = 2;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new("127.0.0.1:9000");
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btnSend.Enabled = false;
            timerLabel.Visible = false;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Player1: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
                wordPool.Items.Add(Encoding.UTF8.GetString(e.Data));
                btnSend.Enabled = true;
                turn = 2;
                turnLabel.Text = $"Player{turn}'s Turn...";
                timer1.Start();
                timer = 10;
                timerLabel.Visible = true;
                
            });
            
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server disconnected. {Environment.NewLine}";
            });
            
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server connected. {Environment.NewLine}";

            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    if (wordPool.Items.Contains(textBox3.Text) || wordPool.Items.Contains(textBox3.Text))
                    {
                        string containsError = "The word you wrote have been sent before. Try a different one.";
                        MessageBox.Show(containsError);
                    }
                    else
                    {
                        last_word = wordPool.Items[wordPool.Items.Count - 1].ToString(); // burasi calismiyor buna bak
                        char[] chars = last_word.ToCharArray();
                        last_letter = chars[chars.Length - 1];
                        before_last_letter = chars[chars.Length - 2];
                        string lastTwoLetters = before_last_letter.ToString() + last_letter.ToString();

                        char[] charTxtMessage = textBox3.Text.ToCharArray();
                        first_letter = charTxtMessage[0];
                        after_first_letter = charTxtMessage[1];
                        string firstTwoLetters = first_letter.ToString() + after_first_letter.ToString();

                        if (lastTwoLetters == firstTwoLetters)
                        {
                            client.Send(textBox3.Text);
                            wordPool.Items.Add(textBox3.Text);
                            txtInfo.Text += $"Player2: {textBox3.Text}{Environment.NewLine}";
                            textBox3.Text = string.Empty;
                            btnSend.Enabled = false;
                            turn = 1;
                            turnLabel.Text = $"Player{turn}'s Turn...";
                            timer = 10;
                        }
                        else
                        {
                            string wrongWord = "The word you wrote doesn't satisfy the game rules. Try a different one.";
                            MessageBox.Show(wrongWord);
                        }
                        
                    }
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
/*              btnSend.Enabled = true;
*/              btnConnect.Enabled = false;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;
            timerLabel.Text = $"{timer.ToString()}s Left.";
            if (timer == 0)
            {
                timer1.Stop();
                if (turn == 1)
                {
                    string timeIsUp = "TIME IS UP. PLAYER2 LOST";
                    MessageBox.Show(timeIsUp);
                }
                else if (turn == 2)
                {
                    string timeIsUp = "TIME IS UP. PLAYER1 WON";
                    MessageBox.Show(timeIsUp);
                }



            }
        }
    }
}
