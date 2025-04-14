using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("-----------Monthway Auto Transport Service-----------------");
                Console.WriteLine("Choose Login type");
                Console.WriteLine("Press 1 : Admin | Press 2 : User | Press 3 : Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Press 1 : Add Route | Press 2 : Add Vehicle");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Transport Car From");
                        string from = Console.ReadLine();

                        Console.WriteLine("Transport Car To");
                        string to = Console.ReadLine();

                        Console.WriteLine("Transport Type");
                        Console.WriteLine("Press 1 : Open | Press 2 | Enclosed");
                        int typeOption = int.Parse(Console.ReadLine());
                      

                        Console.WriteLine("Vehicle year");
                        int year = int.Parse(Console.ReadLine());

                        Console.WriteLine("Vehicle Model");
                        string model = Console.ReadLine();

                        Console.WriteLine("Is it operable");
                        int typeOperable = int.Parse(Console.ReadLine());
                      

                        Console.WriteLine("Enter your Email");
                        
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }
    }
}
