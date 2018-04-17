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
        private double A1, B1, C1, D1;
        private double A2, B2, C2, D2;
        private double A3, B3, C3, D3;


        static private int lengthEnhanced = 4;                                        //кол-во строк и столбцов расширенной матрицы
        static private int lengthBase = 3;                                            //кол-во строк и столбцов основной матрицы

        private double[,] masEnhanced = new double[lengthBase, lengthEnhanced];       //расширенная матрица

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Actions()
        {
            A1 = 0; B1 = 0; C1 = 0; D1 = 0;
            A2 = 0; B2 = 0; C2 = 0; D2 = 0;
            A3 = 0; B3 = 0; C3 = 0; D3 = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="A3"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="B3"></param>
        /// <param name="C1"></param>
        /// <param name="C2"></param>
        /// <param name="C3"></param>
        /// <param name="D1"></param>
        /// <param name="D2"></param>
        /// <param name="D3"></param>
        public Actions(double A1, double A2, double A3, double B1, double B2, double B3, double C1, double C2, double C3, double D1, double D2, double D3)
        {
            this.A1 = A1; this.B1 = B1; this.C1 = C1; this.D1 = D1;
            this.A2 = A2; this.B2 = B2; this.C2 = C2; this.D2 = D2;
            this.A3 = A3; this.B3 = B3; this.C3 = C3; this.D3 = D3;
        }

        /// <summary>
        /// Создание матрицы
        /// </summary>
        /// <param name="masEnhanced"></param>
        /// <returns></returns>
        private double[,] MasCreating()
        {
            //присваиваем введенные значения
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
        private double DeterminantEnhancedMatrix()
        {
            double Determinant;
            double per1, per2, per3, per4, per5, per6;
            
            //находим определитель через треугольники
            per1 = masEnhanced[0, 0] * masEnhanced[1, 1] * masEnhanced[2, 2];
            per2 = masEnhanced[0, 1] * masEnhanced[1, 2] * masEnhanced[2, 0];
            per3 = masEnhanced[0, 2] * masEnhanced[1, 0] * masEnhanced[2, 1];
            per4 = masEnhanced[0, 2] * masEnhanced[1, 1] * masEnhanced[2, 0];
            per5 = masEnhanced[0, 1] * masEnhanced[1, 0] * masEnhanced[2, 2];
            per6 = masEnhanced[0, 0] * masEnhanced[1, 2] * masEnhanced[2, 1];

            double Sum1 = per1 + per2 + per3;
            double Sum2 = per4 + per5 + per6;
            Determinant = Sum1 - Sum2;
            return Determinant;
        }

        /// <summary>
        /// Поиск 1 вспомогательного определителя
        /// </summary>
        /// <param name="masEnhanced"></param>
        /// <returns></returns>
        private double SupportDeterminant1()
        {
            double SupportDeterminant1;                                        //первый вспомогательный определитель
            double[,] masSupport = new double[lengthBase,lengthBase];          //основная матрица
            masSupport = MasCreating();                                        //присваиваем значения основной матрице (без D)

            masSupport[0, 0] = D1;
            masSupport[1, 0] = D2;
            masSupport[2, 0] = D3;

            double per1, per2, per3, per4, per5, per6;

            //находим определитель через треугольники
            per1 = masSupport[0, 0] * masSupport[1, 1] * masSupport[2, 2];
            per2 = masSupport[0, 1] * masSupport[1, 2] * masSupport[2, 0];
            per3 = masSupport[0, 2] * masSupport[1, 0] * masSupport[2, 1];
            per4 = masSupport[0, 2] * masSupport[1, 1] * masSupport[2, 0];
            per5 = masSupport[0, 1] * masSupport[1, 0] * masSupport[2, 2];
            per6 = masSupport[0, 0] * masSupport[1, 2] * masSupport[2, 1];

            double Sum1 = per1 + per2 + per3;
            double Sum2 = per4 + per5 + per6;
            SupportDeterminant1 = Sum1 - Sum2;      //высчитываем вспомогательный определитель
            return SupportDeterminant1;
        }

        /// <summary>
        /// Поиск 2 вспомогательного определителя
        /// </summary>
        /// <param name="masEnhanced"></param>
        /// <returns></returns>
        private double SupportDeterminant2()
        {
            double SupportDeterminant2;                                         //второй вспомогательный определитель
            double[,] masSupport = new double[lengthBase, lengthBase];          //основная матрица
            masSupport = MasCreating();                                           //присваиваем значения основной матрице (без D)

            masSupport[0, 1] = D1;
            masSupport[1, 1] = D2;
            masSupport[2, 1] = D3;

            double per1, per2, per3, per4, per5, per6;

            //находим определитель через треугольники
            per1 = masSupport[0, 0] * masSupport[1, 1] * masSupport[2, 2];
            per2 = masSupport[0, 1] * masSupport[1, 2] * masSupport[2, 0];
            per3 = masSupport[0, 2] * masSupport[1, 0] * masSupport[2, 1];
            per4 = masSupport[0, 2] * masSupport[1, 1] * masSupport[2, 0];
            per5 = masSupport[0, 1] * masSupport[1, 0] * masSupport[2, 2];
            per6 = masSupport[0, 0] * masSupport[1, 2] * masSupport[2, 1];

            double Sum1 = per1 + per2 + per3;
            double Sum2 = per4 + per5 + per6;
            SupportDeterminant2 = Sum1 - Sum2;      //высчитываем вспомогательный определитель
            return SupportDeterminant2;
        }

        /// <summary>
        /// Поиск 3 вспомогательного определителя
        /// </summary>
        /// <param name="masEnhanced"></param>
        /// <returns></returns>
        private double SupportDeterminant3()
        {
            double SupportDeterminant3;                                         //третий вспомогательный определитель
            double[,] masSupport = new double[lengthBase, lengthBase];          //основная матрица
            masSupport = MasCreating();                                         //присваиваем значения основной матрице (без D)

            masSupport[0, 2] = D1;
            masSupport[1, 2] = D2;
            masSupport[2, 2] = D3;

            double per1, per2, per3, per4, per5, per6;

            //находим определитель через треугольники
            per1 = masSupport[0, 0] * masSupport[1, 1] * masSupport[2, 2];
            per2 = masSupport[0, 1] * masSupport[1, 2] * masSupport[2, 0];
            per3 = masSupport[0, 2] * masSupport[1, 0] * masSupport[2, 1];
            per4 = masSupport[0, 2] * masSupport[1, 1] * masSupport[2, 0];
            per5 = masSupport[0, 1] * masSupport[1, 0] * masSupport[2, 2];
            per6 = masSupport[0, 0] * masSupport[1, 2] * masSupport[2, 1];

            double Sum1 = per1 + per2 + per3;
            double Sum2 = per4 + per5 + per6;
            SupportDeterminant3 = Sum1 - Sum2;      //высчитываем вспомогательный определитель
            return SupportDeterminant3;
        }

        /// <summary>
        /// Получаем решение 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void Values(ref double A, ref double B, ref double C)
        {
            masEnhanced = MasCreating();                                        //присваиваем значения матрице     
            double Determinant = DeterminantEnhancedMatrix();                   //получаем определитель основной матрицы       
            double SupDeterminant1 = SupportDeterminant1();                     //получаем первый вспомогательный определитель
            double SupDeterminant2 = SupportDeterminant2();                     //получаем второй вспомогательный определитель
            double SupDeterminant3 = SupportDeterminant3();                     //получаем третий вспомогательный определитель
            
            A = SupDeterminant1 / Determinant;                                  //считаем 1 значение (A или x1)
            B = SupDeterminant2 / Determinant;                                  //считаем 2 значение (B или x2)
            C = SupDeterminant3 / Determinant;                                  //считаем 3 значение (C или x3)
        }


    }
}
