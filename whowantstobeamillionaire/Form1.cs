using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace whowantstobeamillionaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int id = 1;
        int[] money = new Int32[] { 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
        int m = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            readFromDB(id);
            label7.Text = money[m++].ToString();
            timer1.Start();
        }

        string[] answers = new string[4];

        public void Shuffle<T>(T[] arr)
        {
            Random random = new Random();
            int n = arr.Length;
            while (n > 1)
            {
                int k = random.Next(n--);
                T temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
        }

        /*
        public static void Shuffle<T>(Stack<T> stack)
        {
            var values = stack.ToArray();
            stack.Clear();
            foreach (var value in values.OrderBy(x => random.Next()))
                stack.Push(value);
        }
        */

        private void readFromDB(int id)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;

                command = new SqlCommand("SELECT * FROM DATA WHERE id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    label2.Text = dataReader.GetValue(1).ToString();
                    answers[0] = dataReader.GetValue(2).ToString();
                    answers[1] = dataReader.GetValue(3).ToString();
                    answers[2] = dataReader.GetValue(4).ToString();
                    answers[3] = dataReader.GetValue(5).ToString();
                }
                dataReader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
            Shuffle<string>(answers);
            label3.Text = answers[0];
            label4.Text = answers[1];
            label5.Text = answers[2];
            label6.Text = answers[3];
        }

        private string checkAnswer(int id)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            command = new SqlCommand("SELECT * FROM DATA WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            string ans = "";
            while (dataReader.Read())
            {
                ans = dataReader.GetValue(6).ToString();
            }
            return ans;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            reset();
            timer1.Stop();
            if (label3.Text == checkAnswer(id))
            {
                label3.ForeColor = Color.LightGreen;
                label3.Refresh();
                System.Threading.Thread.Sleep(1000);
                panel1.Top -= 23;
                label3.ForeColor = Color.White;
                readFromDB(++id);
                label7.Text = money[m++].ToString();
                time = 30;
                timer1.Start();
            }
            else
            {
                label1.Text = "Попробуй еще(";
                label3.ForeColor = Color.Red;
                DialogResult result = MessageBox.Show("Увы, но вы проиграли...", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            reset();
            timer1.Stop();
            if (label4.Text == checkAnswer(id))
            {
                label4.ForeColor = Color.LightGreen;
                label4.Refresh();
                System.Threading.Thread.Sleep(1000);
                panel1.Top -= 23;
                label4.ForeColor = Color.White;
                readFromDB(++id);
                label7.Text = money[m++].ToString();
                time = 30;
                timer1.Start();
            }
            else
            {
                label1.Text = "Попробуй еще(";
                label4.ForeColor = Color.Red;
                DialogResult result = MessageBox.Show("Увы, но вы проиграли...", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            reset();
            timer1.Stop();
            if (label5.Text == checkAnswer(id))
            {
                label5.ForeColor = Color.LightGreen;
                label5.Refresh();
                System.Threading.Thread.Sleep(1000);
                panel1.Top -= 23;
                label5.ForeColor = Color.White;
                readFromDB(++id);
                label7.Text = money[m++].ToString();
                time = 30;
                timer1.Start();
            }
            else
            {
                label1.Text = "Попробуй еще(";
                label5.ForeColor = Color.Red;
                DialogResult result = MessageBox.Show("Увы, но вы проиграли...", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            reset();
            timer1.Stop();
            if (label6.Text == checkAnswer(id))
            {
                label6.ForeColor = Color.LightGreen;
                label6.Refresh();
                System.Threading.Thread.Sleep(1000);
                panel1.Top -= 23;
                label6.ForeColor = Color.White;
                readFromDB(++id);
                label7.Text = money[m++].ToString();
                time = 30;
                timer1.Start();
            }
            else
            {
                label1.Text = "Попробуй еще(";
                label6.ForeColor = Color.Red;
                DialogResult result = MessageBox.Show("Увы, но вы проиграли...", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
        }

        public void reset()
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (label3.Text == checkAnswer(id))
            {
                label9.Text = random.Next(40, 70).ToString() + "%";
                label10.Text = random.Next(0, 60).ToString() + "%";
                label11.Text = random.Next(0, 60).ToString() + "%";
                label12.Text = random.Next(0, 60).ToString() + "%";
            }
            if (label4.Text == checkAnswer(id))
            {
                label9.Text = random.Next(0, 60).ToString() + "%";
                label10.Text = random.Next(40, 70).ToString() + "%";
                label11.Text = random.Next(0, 60).ToString() + "%";
                label12.Text = random.Next(0, 60).ToString() + "%";
            }
            if (label5.Text == checkAnswer(id))
            {
                label9.Text = random.Next(0, 60).ToString() + "%";
                label10.Text = random.Next(0, 60).ToString() + "%";
                label11.Text = random.Next(40, 70).ToString() + "%";
                label12.Text = random.Next(0, 60).ToString() + "%";
            }
            if (label6.Text == checkAnswer(id))
            {
                label9.Text = random.Next(0, 60).ToString() + "%";
                label10.Text = random.Next(0, 60).ToString() + "%";
                label11.Text = random.Next(0, 60).ToString() + "%";
                label12.Text = random.Next(40, 70).ToString() + "%";
            }
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (label3.Text == checkAnswer(id))
            {
                int i = 0;
                while (true)
                {
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label4.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label5.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label6.Visible = false;
                        i++;
                    }
                }
            }
            if (label4.Text == checkAnswer(id))
            {
                int i = 0;
                while (true)
                {
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label3.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label5.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label6.Visible = false;
                        i++;
                    }
                }
            }
            if (label5.Text == checkAnswer(id))
            {
                int i = 0;
                while (true)
                {
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label3.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label4.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label6.Visible = false;
                        i++;
                    }
                }
            }
            if (label6.Text == checkAnswer(id))
            {
                int i = 0;
                while (true)
                {
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label3.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label4.Visible = false;
                        i++;
                    }
                    if (random.Next(2) == 1)
                    {
                        if (i == 2)
                            break;
                        label5.Visible = false;
                        i++;
                    }
                }
            }
            pictureBox5.Visible = false;
        }

        int time = 30;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                timer1.Stop();
                label1.Text = "Время вышло(";
                MessageBox.Show("Увы, но вы проиграли...");
                Application.Exit();
            }
            else
            {
                time--;
                label8.Text = time.ToString();
            }
        }

        int mouseX;
        int mouseY;
        int mouseinX;
        int mouseinY;
        bool isPressed;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            mouseinX = MousePosition.X - Bounds.X;
            mouseinY = MousePosition.Y - Bounds.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                mouseX = MousePosition.X - mouseinX;
                mouseY = MousePosition.Y - mouseinY;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Абонент не доступен");
            pictureBox4.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Вы забрали $" + money[--m].ToString() + ", но можно было бы и больше :(");
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Проблемы в студии, звук временно отключен");
        }
    }
}