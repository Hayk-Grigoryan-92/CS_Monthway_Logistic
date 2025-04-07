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
                        break;
                    case 2:
                        Console.WriteLine("Transport Car From");
                        string from = Console.ReadLine();

                        Console.WriteLine("Transport Car To");
                        string to = Console.ReadLine();

                        Console.WriteLine("Transport Type");
                        Console.WriteLine("Press 1 : Open | Press 2 | Enclosed");
                        int typeOption = int.Parse(Console.ReadLine());
                        Enum type;
                        if(typeOption == 1)
                        {
                           type = TransportType.Open;
                        }
                        else if(typeOption == 2)
                        {
                            type = TransportType.Enclosed;
                        }
                        else
                        {
                            Console.WriteLine("Wrong type of car");
                            continue;
                        }

                        Console.WriteLine("Vehicle year");
                        int year = int.Parse(Console.ReadLine());

                        Console.WriteLine("Vehicle Model");
                        string model = Console.ReadLine();

                        Console.WriteLine("Is it operable");
                        int typeOperable = int.Parse(Console.ReadLine());
                        Enum operable;
                        if(typeOperable == 1)
                        {
                            operable = Operable.Yes;
                        }else if(typeOperable == 2)
                        {
                            operable = Operable.No;
                        }
                        else
                        {
                            Console.WriteLine("Wrong operable type");
                            continue;
                        }

                        Console.WriteLine("Enter your Email");
                        
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }
    }

    enum TransportType
    {
        Open,
        Enclosed
    }

    enum Operable
    {
        Yes,
        No
    }
}
