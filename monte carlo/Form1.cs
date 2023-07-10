using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monte_carlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g2 = CreateGraphics();
            Random r = new Random();
            Pen p1;


            int krug = 0;
            int tort = 0;


            for (int i = 0; i < 10000; i++)
            {
                int rx = r.Next(50, 351);
                int ry = r.Next(50, 351);

                int radius = (int)Math.Sqrt(Math.Pow(rx - 200, 2) + Math.Pow(ry - 200, 2));
                if (radius <= 150)
                {
                    p1 = new Pen(Color.Orange);
                    krug++;
                }
                else
                {
                    p1 = new Pen(Color.Red);
                    tort++;
                }
                g2.DrawRectangle(p1, rx, ry, 1, 1);
            }
            textBox1.Text = "PI = " + (double)(4 * krug) / 10000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int[,] squares = new int[3, 3];
            Graphics g2 = CreateGraphics();
            Random r = new Random();
            Pen p1;

            for(int i = 0; i < 10000; i++)
            {
                int rx = r.Next(50, 351);
                int ry = r.Next(50, 351);

                if (rx <= 150 && ry <= 150)
                {
                    p1 = new Pen(Color.Orange);
                    squares[0, 0]++;
                }
                else if (rx > 150 && ry <= 150 && rx <= 250)
                {
                    p1 = new Pen(Color.Red);
                    squares[0, 1]++; ;
                }
                else if (rx > 250 && ry <= 150 && rx <= 350)
                {
                    p1 = new Pen(Color.Green);
                    squares[0, 2]++; ;
                }
                else if (rx <= 150 && ry <= 250 && ry > 150)
                {
                    p1 = new Pen(Color.Black);
                    squares[1, 0]++; ;
                }
                else if (rx > 150 && ry <= 250 && rx <= 250)
                {
                    p1 = new Pen(Color.Yellow);
                    squares[1, 1]++; ;
                }
                else if (rx > 250 && ry <= 250 && rx <= 350)
                {
                    p1 = new Pen(Color.Blue);
                    squares[1, 2]++; ;
                }
                else if (rx <= 150 && ry <= 350 && ry > 250)
                {
                    p1 = new Pen(Color.Pink);
                    squares[2, 0]++; ;
                }
                else if (rx <= 250 && rx > 150 || ry <= 250 && ry > 150)
                {
                    p1 = new Pen(Color.Purple);
                    squares[2, 1]++; ;
                }
                else
                {
                    p1 = new Pen(Color.Brown);
                    squares[2, 2]++;
                }
                g2.DrawRectangle(p1, rx, ry, 1, 1);
            }

            string res = "";
            for (int i = 0; i < 3; i++)
            {
                res += "| ";
                for (int j = 0; j < 3; j++)
                {
                    listView1.Items.Add(Math.Round((squares[i, j]) / 10000.0, 3).ToString());
                }
                res += "\n";
            }

        }
        }
}
