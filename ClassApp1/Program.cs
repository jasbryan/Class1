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
                            var accountTypeOption = Console.ReadLine();
                            //var accountType = (string.IsNullOrEmpty(accountTypeOption)) ?  : (TypesofAccount)Enum.Parse(typeof(TypesofAccount), accountTypes[Convert.ToInt32(accountTypeOption) - 1]);
                            var accountType = (TypesofAccount)Enum.Parse(typeof(TypesofAccount), accountTypes[Convert.ToInt32(accountTypeOption) - 1]);
                            Console.Write("Initial Deposit:");
                            var amountText = Console.ReadLine();
                            //var amount = (string.IsNullOrEmpty(amountText)) ? null : Convert.ToDecimal(amountText);
                            var amount = Convert.ToDecimal(amountText);
                            var account = Bank.CreateAccount(emailAddress, accountType, amount);
                            Console.WriteLine($"AN: {account.AccountNumber}, Type: {account.AccountType}, Balance: {account.Balance}");
                        }
                        catch (FormatException fx)
                        {
                            Console.WriteLine($"Invalid Data: {fx.Message}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Something crazy went wrong:{ex.Message}");
                        }
                        break;
                    case "2":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Eneter account number to deposit to:");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Deposit:");
                            var depositAmount = Convert.ToDecimal(Console.ReadLine());
                            var newBalance = Bank.Deposit(accountNumber, depositAmount);
                            Console.WriteLine($"Your account has been credited, new balance is: {newBalance}");
                        }
                        catch(FormatException fx)
                        {
                            Console.WriteLine($"{fx.Message}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        break;
                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Eneter account number to withdraw from :");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Withdraw:");
                            var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                            var newBalance = Bank.Withdraw(accountNumber, withdrawAmount);
                            Console.WriteLine($"Your account has been credited, new balance is: {newBalance}");
                        }
                        catch (FormatException fx)
                        {
                            Console.WriteLine($"{fx.Message}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
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
