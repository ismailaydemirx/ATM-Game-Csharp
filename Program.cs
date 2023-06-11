public class cardHolder
{
    int id;
    string cardNum;
    string firstName;
    string lastName;
    int pin;
    double balance;

    public cardHolder(int id, string cardNum, string firstName, string lastName, int pin, double balance)
    {
        this.id = id;
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
    }

    // Getters;

    public int getId(int id)
    {
        return id;
    }

    public string getCardNum(string cardNum)
    {
        return cardNum;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public int getPin()
    {
        return pin;
    }

    public double getBalance()
    {
        return balance;
    }

    // Setters;
    public void setCardNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {


        void printOptions()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Your Money is Safe With AYDEMIR BANK");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
            Console.Write("Choose an option: ");
        }

        void deposit(cardHolder currentUser)
        {
            Console.Write("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit+currentUser.getBalance());
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withDraw(cardHolder currentUser)
        {
            Console.Write("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // Check if the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {

                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + ",");
            Console.WriteLine("Your current balance is $$" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder(12, "1234567890", "John", "Doe", 1234, 100.0));
        cardHolders.Add(new cardHolder(23, "9876543210", "Jane", "Smith", 5678, 250.15));
        cardHolders.Add(new cardHolder(34, "4567890123", "Michael", "Johnson", 9012, 50.53));
        cardHolders.Add(new cardHolder(45, "7890123456", "Emily", "Williams", 3456, 350.0));
        cardHolders.Add(new cardHolder(56, "2345678901", "David", "Brown", 7890, 200.47));

        // Prompt user
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("WELCOME TO THE AYDEMIR BANK");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine();
        Console.Write("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Chechk against our database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                    Console.Write("Please insert your debit card: ");
                }
            }
            catch { Console.WriteLine("Card not recognized. Please try again. debit"); }
        }


        // Pin Control
        Console.Write("Please enter your pin: ");
        int userPin;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Chechk against our database
                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                    Console.Write("Please enter your pin: ");
                }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }
        Console.WriteLine();
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withDraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            catch
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
        while (option != 4);
        {
            Console.WriteLine("Thank you! Have a nice day :)");
        }
    }
}