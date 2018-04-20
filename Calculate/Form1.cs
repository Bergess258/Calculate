using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        static List<double[]> ListForRam= new List<double[]>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = false;
            double[] mas = new double[12];
            string[] masString = new string[12];
            masString[0] = A1.Text;
            masString[1] = A2.Text;
            masString[2] = A3.Text;
            masString[3] = B1.Text;
            masString[4] = B2.Text;
            masString[5] = B3.Text;
            masString[6] = C1.Text;
            masString[7] = C2.Text;
            masString[8] = C3.Text;
            masString[9] = D1.Text;
            masString[10] = D2.Text;
            masString[11] = D3.Text;
            for (int i = 0; i < mas.Length; i++)
            {
                ok = Double.TryParse(masString[i],out mas[i]);
                if (ok == false) { MessageBox.Show("Введены неверные коэффициенты","Ошибка"); return; }
            }
            if (ListForRam.Count <= 4)
            {
                ListForRam.Add(mas);
            }
            else ListForRam.Insert(0, mas);
            try
            {
                this.label2.Text = ListForRam[0][0] + "A" + "+" + ListForRam[0][3] + "B" + "+" + ListForRam[0][6] + "C" + "=" + ListForRam[0][9];
                this.label8.Text = ListForRam[0][1] + "A" + "+" + ListForRam[0][4] + "B" + "+" + ListForRam[0][7] + "C" + "=" + ListForRam[0][10];
                this.label9.Text = ListForRam[0][2] + "A" + "+" + ListForRam[0][5] + "B" + "+" + ListForRam[0][8] + "C" + "=" + ListForRam[0][11];
                this.label21.Text = ListForRam[1][0] + "A" + "+" + ListForRam[1][3] + "B" + "+" + ListForRam[1][6] + "C" + "=" + ListForRam[1][9];
                this.label17.Text = ListForRam[1][1] + "A" + "+" + ListForRam[1][4] + "B" + "+" + ListForRam[1][7] + "C" + "=" + ListForRam[1][10];
                this.label13.Text = ListForRam[1][2] + "A" + "+" + ListForRam[1][5] + "B" + "+" + ListForRam[1][8] + "C" + "=" + ListForRam[1][11];
                this.label30.Text = ListForRam[2][0] + "A" + "+" + ListForRam[2][3] + "B" + "+" + ListForRam[2][6] + "C" + "=" + ListForRam[2][9];
                this.label29.Text = ListForRam[2][1] + "A" + "+" + ListForRam[2][4] + "B" + "+" + +ListForRam[2][7] + "C" + "=" + ListForRam[2][10];
                this.label28.Text = ListForRam[2][2] + "A" + "+" + ListForRam[2][5] + "B" + "+" + +ListForRam[2][8] + "C" + "=" + ListForRam[2][11];
                this.label34.Text = ListForRam[3][0] + "A" + "+" + ListForRam[3][3] + "B" + "+" + ListForRam[3][6] + "C" + "=" + ListForRam[3][9];
                this.label33.Text = ListForRam[3][1] + "A" + "+" + ListForRam[3][4] + "B" + "+" + ListForRam[3][7] + "C" + "=" + ListForRam[3][10];
                this.label32.Text = ListForRam[3][2] + "A" + "+" + ListForRam[3][5] + "B" + "+" + ListForRam[3][8] + "C" + "=" + ListForRam[3][11];
            }
            catch { }
            Actions Temp = new Actions(mas[0], mas[1], mas[2], mas[3], mas[4], mas[5], mas[6], mas[7], mas[8], mas[9], mas[10],mas[11]);
            double x1=0, x2=0, x3=0;
            Temp.Values(ref x1, ref x2, ref x3);
            string s = "A="+x1+"\nB="+x2+"\nC="+x3;
            MessageBox.Show(s);
            int c = 0;
            if (c==0)
            {
                //1 система
                
                c++;
                return;
            }

            if (c==1)
            {
                //2 система
                
                c++;
                return;
            }
            if (string.IsNullOrEmpty(label30.Text) && string.IsNullOrEmpty(label29.Text) && string.IsNullOrEmpty(label28.Text))
            {
                //3 система
                

                return;
            }
            if (string.IsNullOrEmpty(label34.Text) && string.IsNullOrEmpty(label33.Text) && string.IsNullOrEmpty(label32.Text))
            {
                //4 система
                
                return;
            }



        }

        private void A1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                A1.Text = Convert.ToString(ListForRam[0][0]);
                A2.Text = Convert.ToString(ListForRam[0][1]);
                A3.Text = Convert.ToString(ListForRam[0][2]);
                B1.Text = Convert.ToString(ListForRam[0][3]);
                B2.Text = Convert.ToString(ListForRam[0][4]);
                B3.Text = Convert.ToString(ListForRam[0][5]);
                C1.Text = Convert.ToString(ListForRam[0][6]);
                C2.Text = Convert.ToString(ListForRam[0][7]);
                C3.Text = Convert.ToString(ListForRam[0][8]);
                D1.Text = Convert.ToString(ListForRam[0][9]);
                D2.Text = Convert.ToString(ListForRam[0][10]);
                D3.Text = Convert.ToString(ListForRam[0][11]);
            }
            catch  (Exception exception) { MessageBox.Show("Нет данных для заполнения", "Ошибка"); }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                A1.Text = Convert.ToString(ListForRam[1][0]);
                A2.Text = Convert.ToString(ListForRam[1][1]);
                A3.Text = Convert.ToString(ListForRam[1][2]);
                B1.Text = Convert.ToString(ListForRam[1][3]);
                B2.Text = Convert.ToString(ListForRam[1][4]);
                B3.Text = Convert.ToString(ListForRam[1][5]);
                C1.Text = Convert.ToString(ListForRam[1][6]);
                C2.Text = Convert.ToString(ListForRam[1][7]);
                C3.Text = Convert.ToString(ListForRam[1][8]);
                D1.Text = Convert.ToString(ListForRam[1][9]);
                D2.Text = Convert.ToString(ListForRam[1][10]);
                D3.Text = Convert.ToString(ListForRam[1][11]);
            }
            catch { }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                A1.Text = Convert.ToString(ListForRam[2][0]);
                A2.Text = Convert.ToString(ListForRam[2][1]);
                A3.Text = Convert.ToString(ListForRam[2][2]);
                B1.Text = Convert.ToString(ListForRam[2][3]);
                B2.Text = Convert.ToString(ListForRam[2][4]);
                B3.Text = Convert.ToString(ListForRam[2][5]);
                C1.Text = Convert.ToString(ListForRam[2][6]);
                C2.Text = Convert.ToString(ListForRam[2][7]);
                C3.Text = Convert.ToString(ListForRam[2][8]);
                D1.Text = Convert.ToString(ListForRam[2][9]);
                D2.Text = Convert.ToString(ListForRam[2][10]);
                D3.Text = Convert.ToString(ListForRam[2][11]);
            }
            catch { }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                A1.Text = Convert.ToString(ListForRam[3][0]);
                A2.Text = Convert.ToString(ListForRam[3][1]);
                A3.Text = Convert.ToString(ListForRam[3][2]);
                B1.Text = Convert.ToString(ListForRam[3][3]);
                B2.Text = Convert.ToString(ListForRam[3][4]);
                B3.Text = Convert.ToString(ListForRam[3][5]);
                C1.Text = Convert.ToString(ListForRam[3][6]);
                C2.Text = Convert.ToString(ListForRam[3][7]);
                C3.Text = Convert.ToString(ListForRam[3][8]);
                D1.Text = Convert.ToString(ListForRam[3][9]);
                D2.Text = Convert.ToString(ListForRam[3][10]);
                D3.Text = Convert.ToString(ListForRam[3][11]);
            }
            catch { }
            
        }
    }
}
