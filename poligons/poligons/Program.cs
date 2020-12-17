using System;

namespace poligons
{
    class Program
    {
        static bool getV(float x0, float y0, float x1, float y1, float xn, float yn)
        {
            float[] kbnF = new float[3];
            
            float k = (y1 - y0) / (x1 - x0);
            float b = y0 - k * x0;

            if ((x1 > x0) && (y1 > y0)) // 0
            {
                return yn < (k * xn + b);
            }
            else if ((y0 == y1) && (x1 > x0)) // 1
            {
                return yn < y1;
            }
            else if ((x1 > x0) && (y1 < y0)) // 2
            {
                return yn < (k * xn + b);
            }
            else if ((x0 == x1) && (y1 < y0)) // 3
            {
                return xn < x1;
            }
            else if ((x1 < x0) && (y1 < y0)) // 4
            {
                return yn > (k * xn + b);
            }
            else if ((y1 == y0) && (x1 < x0)) // 5
            {
                return yn > y1;
            }
            else if ((x1 < x0) && (y1 > y0)) // 6
            {
                return yn > (k * xn + b);
            }
            else if ((x0 == x1) && (y1 > y0)) // 7
            {
                return xn > x1;
            }
            else
            {
                return false;
            }
        }


        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин многоугольника: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите поочередно координаты точек через пробел: ");
            float[] x = new float[count];
            float[] y = new float[count];
            //float[] k = new float[count];
            bool v;
            int temp = 0;
            string str;
            string[] s_arr;
            for (int i = 0; i < count; i++)
            {
                str = Console.ReadLine();// знакомтесь! Это костыль номер один. Его зовут Костя
                s_arr = str.Split();
                x[i] = int.Parse(s_arr[0]);
                y[i] = int.Parse(s_arr[1]);
            } // объявление Х и У

            int iPlus;
            int iPlus2;
            for (int i = 0; i < count; i++)
            {
                iPlus = i + 1;
                iPlus2 = i + 2;
                if ((i + 1) >= count) // Встречайте! Это костыль номер два. Его зовут Александр
                {
                    iPlus = 0;
                    iPlus2 = 1;
                } else 
                if ((i + 2) >= count)
                {
                    iPlus2 = 0;
                }

                v = getV(x[i], y[i], x[iPlus], y[iPlus], x[iPlus2], y[iPlus2]);
                // Console.WriteLine(v);
                if (temp == 0) // Позвольте представить вам костыль номер три. Это Леня
                {
                    if (v)
                    {
                        temp = 2;
                    }
                    else
                    {
                        temp = 1;
                    }
                }
                else
                {
                    if (temp == 1)
                    {
                        if (v)
                        {
                            Console.WriteLine("не");
                            break;
                        }
                    }
                    if (temp == 2)
                    {
                        if (!v)
                        {
                            Console.Write("не"); // Разрешите показать вам мой самый любимый костыль, который не совсем костыль. Это Роман
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("выпуклый");
            Console.ReadLine();
        }
    }
}


/*
невыпуклые:

4
0 6
1 3
4 2
0 0

6
0 7
3 7
0 5
3 2
0 0
2 4

выпуклые:

5
1 5
5 5
6 3
4 1
0 0

*/