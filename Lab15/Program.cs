using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tАрифметическая прогрессия\n");
            ArithProgression AP = new ArithProgression();

            try
            {
                Console.Write(" Введите начальное значение ряда: ");
                AP.SetStart(Convert.ToInt32(Console.ReadLine()));
                Console.Write(" Введите величину шага ряда: ");
                AP.StepVal = Convert.ToInt32(Console.ReadLine());

                Console.Write(" Генерируемый ряд прогрессии: {0} ", AP.StartVal);            
                do
                {
                    Console.Write(AP.GetNext() + " ");
                    Console.ReadKey(true);
                } while (!Console.CapsLock); //Хотел сделать так, чтобы генерация ряда была бесконечной и прерывалась нажатием определённой клавиши

                Console.WriteLine();
                AP.Reset();
                Console.WriteLine(" Начальное значение: " + AP.GetNext());

            }
            catch (FormatException)
            {
                Console.WriteLine("\n\tВведённое значение не является числом.");
            }

            Console.WriteLine("\tГеометрическая прогрессия\n");
            GeomProgression GP = new GeomProgression();

            try
            {
                Console.Write(" Введите начальное значение ряда: ");
                GP.SetStart(Convert.ToInt32(Console.ReadLine()));
                Console.Write(" Введите знаменатель прогрессии: ");
                GP.Ratio = Convert.ToInt32(Console.ReadLine());

                Console.Write(" Генерируемый ряд прогрессии: {0} ", GP.StartVal);
                do
                {
                    Console.Write(GP.GetNext() + " ");
                    Console.ReadKey(true);
                } while (!Console.CapsLock);

                Console.WriteLine();
                GP.Reset();
                Console.WriteLine(" Начальное значение: " + GP.GetNext());

            }
            catch (FormatException)
            {
                Console.WriteLine("\n\tВведённое значение не является числом.");
            }
            Console.ReadKey();
        }

        interface ISeries
        {
            void SetStart(int x);
            int GetNext();
            void Reset();
        }
        class ArithProgression : ISeries
        {
            public int StartVal { get; set; }
            public int StepVal { get; set; }
            int NextVal { get; set; }
            int StepSum { get; set; }

            public int GetNext()
            {
                StepSum += StepVal;
                NextVal = StepSum + StartVal;
                return NextVal;
            }

            public void Reset()
            {
                StepSum = -StepVal;
            }

            public void SetStart(int x)
            {
                StartVal = x;
            }
        }

        class GeomProgression : ISeries
        {
            int ratio;
            int ratioPow;

            public int StartVal { get; set; }
            public int NextVal { get; set; }

            public int Ratio
            {
                set
                {
                    if (value != 0)
                        ratio = value;
                    else
                        Console.WriteLine("\n\tЗначение знаменателя прогрессии должно быть не равно 0");
                }
                get
                {
                    return ratio;
                }
            }

            public int GetNext()
            {
                ratioPow++;
                NextVal = StartVal * (int)Math.Pow(ratio, ratioPow);
                return NextVal;
            }

            public void Reset()
            {
                ratioPow = -1;
            }

            public void SetStart(int x)
            {
                StartVal = x;
            }
        }
    }
}
