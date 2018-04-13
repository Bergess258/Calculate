using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Data
    {
        private double a,b,c,d;//коэфы
        private bool roots;//имеет ли решение
        private x,y,z;
        public double A 
        {
            get{return a;}
            set{a=value;}
        }
        public double B 
        {
            get{return b;}
            set{b=value;}
        }
        public double C 
        {
            get{return c;}
            set{c=value;}
        }
        public double D 
        {
            get{return d;}
            set{d=value;}
        }
        public double X 
        {
            get{return x;}
            set{x=value;}
        }
        public double Y 
        {
            get{return y;}
            set{y=value;}
        }
        public double Z 
        {
            get{return z;}
            set{z=value;}
        }
        public bool Roots 
        {
            get{return roots;}
            set{roots=value;}
        }
    }
}
