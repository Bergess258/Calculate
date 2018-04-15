using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Actions
    {
        /// <summary>
        /// Значения уравнений матрицы
        /// </summary> 
        static protected double A1 = 0, B1 = 0, C1 = 0, D1 = 0;
        static protected double A2 = 0, B2 = 0, C2 = 0, D2 = 0;
        static protected double A3 = 0, B3 = 0, C3 = 0, D3 = 0;


        static protected int lengthEnhanced = 4;
        static protected int lengthBase = 3;

        double[,] masEnhanced = new double[lengthBase, lengthEnhanced];
        double[,] masBase = new double[lengthBase, lengthBase];

        public static double[,] MasCreating(double[,] masEnhanced)
        {
            masEnhanced[0, 0] = A1;
            masEnhanced[0, 1] = B1;
            masEnhanced[0, 2] = C1;
            masEnhanced[0, 3] = D1;

            masEnhanced[1, 0] = A2;
            masEnhanced[1, 1] = B2;
            masEnhanced[1, 2] = C2;
            masEnhanced[1, 3] = D2;

            masEnhanced[2, 0] = A3;
            masEnhanced[2, 1] = B3;
            masEnhanced[2, 2] = C3;
            masEnhanced[2, 3] = D3;


            return masEnhanced;
        }

        /// <summary>
        /// Определитель матрицы
        /// </summary>
        /// <param name="masEnhanced"></param>
        /// <returns></returns>
        public static double OpredelitelEnhancedMatrix(double[,] masEnhanced)
        {
            double Opredelitel = 0;
            double per1, per2, per3, per4, per5, per6;

            per1 = masEnhanced[0, 0] * masEnhanced[1, 1] * masEnhanced[2, 2];
            per2 = masEnhanced[0, 1] * masEnhanced[1, 2] * masEnhanced[2, 0];
            per3 = masEnhanced[0, 2] * masEnhanced[1, 0] * masEnhanced[2, 1];
            per4 = masEnhanced[0, 2] * masEnhanced[1, 1] * masEnhanced[2, 0];
            per5 = masEnhanced[0, 1] * masEnhanced[1, 0] * masEnhanced[2, 2];
            per6 = masEnhanced[0, 1] * masEnhanced[1, 2] * masEnhanced[2, 1];

            Opredelitel = per1 - per2 - per3 - per4 - per5 - per6;
            return Opredelitel;
        }
    }
}
