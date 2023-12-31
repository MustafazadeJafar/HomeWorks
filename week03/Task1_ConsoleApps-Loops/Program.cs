﻿namespace Task1_ConsoleApps_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.Array element sayi
            int[] array = { 1, -1, -777, 42, 654345, 0, 0, 0, 4, -777, 1, -3, -3 };
            // temporary values
            int max = array[0];
            int min = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i]) max = array[i];
                if (min > array[i] && array[i] < 0) min = array[i];
            }

            int[] arrPositive = new int[max + 1];
            int[] arrNegative = new int[min * (-1) + 1];

            // method itself
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];

                if (element > 0)
                {
                    arrPositive[element] += 1;
                }
                else
                {
                    arrNegative[-element] += 1;
                }
            }

            // showcase
            for (int i = arrNegative.Length - 1; i > -1; i--)
            {
                if (arrNegative[i] != 0)
                {
                    Console.WriteLine((-1) * (i) + " -> " + arrNegative[i] + " dene");
                }
            }
            for (int i = 0; i < arrPositive.Length; i++)
            {
                if (arrPositive[i] != 0)
                {
                    Console.WriteLine(i + " -> " + arrPositive[i] + " dene");
                }
            }


            // 2.Console app
            Console.Write("Give me length of array: ");
            string sInput = Console.ReadLine();
            string interface1 = "Would you like to fill array?: ";

            int input = Convert.ToInt32(sInput);
            int index = 0;
            int[] array2 = new int[input];

            do
            {
                Console.Write(interface1);
                sInput = Console.ReadLine();

                if ((sInput == "Yes" || sInput == "yes" || sInput == "Y" || sInput == "y") && index < array2.Length)
                {
                    interface1 = "[" + index + "]: ";
                    do
                    {
                        Console.Write(interface1);
                        input = Convert.ToInt32(Console.ReadLine());
                        interface1 = "Number can be only less than length of array: ";
                    } while (input > array2.Length);

                    array2[index] = input;
                    index++;
                }
                else
                {
                    break;
                }

                interface1 = "Wish to continue?: ";
            } while (true);

            // end of program
        }
    }
}