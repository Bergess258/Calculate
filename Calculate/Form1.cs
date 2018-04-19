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
         
            for (int i = 0; i < mas.Length; i++)
            {
                ok = Double.TryParse(masString[i],out mas[i]);
                if (ok == false) { MessageBox.Show("Введены неверные коэффициенты"); return; }
            }
            Actions Temp = new Actions(mas[0], mas[1], mas[2], mas[3], mas[4], mas[5], mas[6], mas[7], mas[8], mas[9], mas[10],mas[11]);
            double x1=0, x2=0, x3=0;
            Temp.Values(ref x1, ref x2, ref x3);
            string s = "A="+x1+"\nB="+x2+"\nC="+x3;
            MessageBox.Show(s);
            if (string.IsNullOrEmpty(label2.Text) && string.IsNullOrEmpty(label8.Text) && string.IsNullOrEmpty(label9.Text))
            {
                //1 система
                this.label2.Text = this.A1.Text + "A" +"+"+this.B1.Text+"B"+"+"+this.C1.Text+"C" +"="+ this.D1.Text;
                this.label8.Text = this.A2.Text + "A" +"+"+this.B2.Text +"B"+"+"+this.C2.Text +"C"+"="+ this.D2.Text;
                this.label9.Text = this.A3.Text + "A"+"+" +this.B3.Text + "B" + "+" + this.C3.Text + "C" + "=" + this.D3.Text;
                return;
            }

            if (string.IsNullOrEmpty(label21.Text) && string.IsNullOrEmpty(label17.Text) && string.IsNullOrEmpty(label13.Text))
            {
                //2 система
                this.label21.Text = this.A1.Text + "A" + "+" + this.B1.Text + "B" + "+" + this.C1.Text + "C" + "=" + this.D1.Text;
                this.label17.Text = this.A2.Text + "A" + "+" + this.B2.Text + "B" + "+" + this.C2.Text + "C" + "=" + this.D2.Text;
                this.label13.Text = this.A3.Text + "A" + "+" + this.B3.Text + "B" + "+" + this.C3.Text + "C" + "=" + this.D3.Text;
                return;
            }
            if (string.IsNullOrEmpty(label30.Text) && string.IsNullOrEmpty(label29.Text) && string.IsNullOrEmpty(label28.Text))
            {
                //3 система
                this.label30.Text = this.A1.Text + "A" + "+" + this.B1.Text + "B" + "+" + this.C1.Text + "C" + "=" + this.D1.Text;
                this.label29.Text = this.A2.Text + "A" + "+" + this.B2.Text + this.C2.Text + "C" + "=" + this.D2.Text;
                this.label28.Text = this.A3.Text + "A" + "+" + this.B3.Text + this.C3.Text + "C" + "=" + this.D3.Text;
                return;
            }
            if (string.IsNullOrEmpty(label34.Text) && string.IsNullOrEmpty(label33.Text) && string.IsNullOrEmpty(label32.Text))
            {
                //4 система
                this.label34.Text = this.A1.Text + "A" + "+" + this.B1.Text + "B" + "+" + this.C1.Text + "C" + "=" + this.D3.Text;
                this.label33.Text = this.A2.Text + "A" + "+" + this.B2.Text + "B" + "+" + this.C2.Text + "C" + "=" + this.D3.Text;
                this.label32.Text = this.A3.Text + "A" + "+" + this.B3.Text + "B" + "+" + this.C3.Text + "C" + "=" + this.D3.Text;
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
    }
}
