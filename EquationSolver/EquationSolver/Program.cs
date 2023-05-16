using System;
using System.Data;

namespace FunctionSolver // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            
            
            string function = "2 * x";
            float start = 0f;
            float end = 10f;
            float step = 1f;

            while (running)
            {
                GetUserValue(ref function, "function");
                GetUserValue(ref start, "start number");
                GetUserValue(ref end, "end number");
                GetUserValue(ref step, "step");

                for (float i = start; i <= end; i += step)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"X: {i}, f(x) = {ComputeFunction(function, i)}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                
                Console.Write("Solve another? (Write \"no\" to exit): ");
                string? exit = Console.ReadLine();

                if (exit.ToLower() == "no")
                {
                    running = false;
                }
            }


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Goodbye!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }


        static float ComputeFunction(string function, float x)
        {
            string replaceX = x.ToString();
            //If x is negative put it inside ()
            if (x < 0)
            {
                replaceX = $"({x.ToString()})";
            }

            //Replace the x in a function
            function = function.Replace("x", replaceX);

            DataTable dt = new DataTable();
            var v = dt.Compute(function, "");

            float output = Convert.ToSingle(v);

            return output;
        }

        static void GetUserValue<T>(ref T variable, string variableName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Please enter a value for {variableName}: ");
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            T originalValue = variable;

            try
            {
                variable = (T)Convert.ChangeType(input, typeof(T));
                Console.WriteLine($"{variableName} value set to: {variable}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid input. {variableName} value not set. Using original value: {originalValue}");
            }
        }
    }
}