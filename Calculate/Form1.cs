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
            for(int i = 0; i < mas.Length; i++)
            {
                ok = Double.TryParse(masString[i],out mas[i]);
                if (ok == false) { MessageBox.Show("Введены неверные коэффициенты"); return; }
            }
            Actions Temp = new Actions(mas[0], mas[1], mas[2], mas[3], mas[4], mas[5], mas[6], mas[7], mas[8], mas[9], mas[10],mas[11]);
            double x1=0, x2=0, x3=0;
            Temp.Values(ref x1, ref x2, ref x3);
            string s = "A="+x1+"\nB="+x2+"\nC="+x3;
            MessageBox.Show(s);
        }
    }
}
