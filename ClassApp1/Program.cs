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
                        try
                        {
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
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"We got a fun exception: {e}");
                        }
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Eneter account number to deposit to:");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Deposit:");
                        var depositAmount = Convert.ToDecimal(Console.ReadLine());
                        var newBalance = Bank.Deposit(accountNumber, depositAmount);
                        Console.WriteLine($"Your account has been credited, new balance is: {newBalance}");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Eneter account number to withdraw from :");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to Withdraw:");
                        var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        newBalance = Bank.Withdraw(accountNumber, withdrawAmount);
                        Console.WriteLine($"Your account has been credited, new balance is: {newBalance}");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    default:
                        break;
                }
            }


        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var acct in accounts)
            {
                Console.WriteLine($"AN: {acct.AccountNumber} , Type: {acct.AccountType}, Balance: {acct.Balance}");
            }
        }
    }
}
