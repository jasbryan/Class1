using System;

namespace ClassApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Welcome to NAthan's bank");
            Console.WriteLine("**********************");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit money");
                Console.WriteLine("3. Withdraw money");
                Console.WriteLine("4. Print all accounts");
                Console.Write("Please select an option:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        Console.Write("email address:");
                        var emailAddress = Console.ReadLine();
                        var accountTypes = Enum.GetNames(typeof(TypesofAccount));
                        Console.WriteLine("Please pick an account type:");
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {accountTypes[i]}");
                        }
                        Console.Write("Please select number:");
                        var accountTypeOption = Convert.ToInt32(Console.ReadLine());
                        var accountType = (TypesofAccount)Enum.Parse(typeof(TypesofAccount), accountTypes[accountTypeOption - 1]);
                        Console.Write("Initial Deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, Type: {account.AccountType}, Balance: {account.Balance}");
                        break;
                    case "2":
                        break;
                    default:
                        break;
                }
            }


        }
    }
}
