using System;
using System.IO;

namespace Bank_App
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To Frank's Bank!");
            Console.WriteLine("Most Reliable way to keep your money!");
            Console.WriteLine("~~~~~~~~~~~");

            Console.WriteLine("Enter Your Account Username");
            var fileName = Console.ReadLine();
            var filePath = $"C:/Bank File/{fileName}.txt";


            if (File.Exists(filePath) == true)
            {

                Console.WriteLine("Welcome!, What would you like to do today");


            }
            else
            {
                Console.WriteLine("File Does Not exist\n ..Choose option 1 to create an account");

            }

            var balance = 0;
            var x = 0;
            var deposit = 0;
            var withdraw = 0;
            while (true)
            {
                Console.WriteLine("Below are the following options : ");
                Console.WriteLine("1. Create an account with us");
                Console.WriteLine("2. Check your account balance");
                Console.WriteLine("3. Deposit into your account");
                Console.WriteLine("4. Withhdraw from your account");
                Console.WriteLine("5. Check your Bank Statement");
                Console.WriteLine("6. Exit if you dont wish to carry any other transaction");

                Console.WriteLine("ENTER NUMBER TO CARRY OUT DESIRED ACTION");
                x = int.Parse((Console.ReadLine()));
                Console.ReadKey();


                if (x == 1)
                {
                    Console.WriteLine("Enter New Account Name");
                    fileName = Console.ReadLine();
                    FileStream fs = new FileStream($"C:/Bank File/{fileName}.txt", FileMode.Create);
                    FileStream file2 = new FileStream($"C:/Bank File/{fileName}2.txt", FileMode.Create);
                    fs.Close();
                    filePath = $"C:/Bank File/{fileName}.txt";
                    Console.Write("Your Account Has Been Created, Welcome to our banking family!....Click enter to go back to the main menu");
                    Console.ReadKey();
                }

                if (x == 2)
                {


                    Console.WriteLine("\n YOUR BALANCE IS : {0} ", balance);

                }
                if (x == 3)
                {

                    string file = $"C:/Bank File/{fileName}.txt";
                    string file2 = $"C:/Bank File/{fileName}2.txt";

                    using (TextWriter writer = File.AppendText(file))
                    {

                        Console.WriteLine("\n ENTER THE AMOUNT TO DEPOSIT");
                        deposit = int.Parse(Console.ReadLine());
                        balance = deposit + balance;
                        writer.WriteLine($"You just deposited {deposit}  Your total balance = {balance}");

                        Console.WriteLine("Your Money has been deposited");
                        Console.WriteLine("YOUR BALANCE IS {0}", balance);

                    }


                    using (TextWriter writer = File.CreateText(file2))
                    {
                        writer.WriteLine(balance);
                        writer.Close();

                    }
                }

                if (x == 4)
                {

                    string file = $"C:/Bank File/{fileName}.txt";
                    string file2 = $"C:/Bank File/{fileName}2.txt";
                    using (TextWriter writer = File.AppendText(file))
                    {

                        Console.WriteLine("\n ENTER THE AMOUNT TO WITHDRAW: ");
                        withdraw = int.Parse(Console.ReadLine());

                        if (withdraw % 100 != 0)
                        {
                            Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN MULTIPLES OF 100");
                        }
                        else if (withdraw > (balance - 500))
                        {
                            Console.WriteLine("\n INSUFFICENT BALANCE");
                        }
                        else
                        {
                            balance = balance - withdraw;
                            Console.WriteLine("\n\n PLEASE COLLECT Your CASH!");
                            writer.WriteLine($"You just withdrew {withdraw}  Your total balance = {balance}");
                        }
                    }
                    using (TextWriter writer2 = File.CreateText(file2))
                    {
                        writer2.WriteLine(balance);
                        writer2.Close();

                    }





                }
                if (x == 5)
                {
                    using (TextReader tr = File.OpenText($"C:/Bank File/{fileName}.txt"))
                    {
                        Console.WriteLine(tr.ReadToEnd());
                    }
                    Console.ReadKey();
                }
                if (x == 6)
                {
                    Console.WriteLine("Thank you for banking with us, Hope to see you again! ");
                    Console.WriteLine("Press Enter key to exit");
                    Console.ReadKey();

                    Environment.Exit(0);
                }



            }
        }
    }
}
