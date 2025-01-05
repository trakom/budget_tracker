import os

def read_balance():
    if os.path.exists("balance.txt"):
        with open("balance.txt", "r") as file:
            try:
                return float(file.read())
            except ValueError:
                return 0
    else:
        return 0

def save_balance(balance):
    with open("balance.txt", "w") as file:
        file.write(f"{balance:.2f}")

def clear_screen():
    if os.name == 'nt':  
        os.system('cls')
    

def main():
    balance = read_balance()

    while True:
        clear_screen()  
        print("\n--- Budget Tracker ---")
        print("1. Add Income")
        print("2. Add Expenses")
        print("3. View Balance")
        print("4. Exit")
        
        choice = input("Choose an option (1-4): ")

        if choice == '1':
            try:
                income = float(input("Enter income amount: $"))
                balance += income
                print(f"Income added: ${income:.2f}")
                save_balance(balance)
            except ValueError:
                print("Invalid input. Please enter a valid number.")
            input("Press Enter to continue...")

        elif choice == '2':
            try:
                expenses = float(input("Enter expense amount: $"))
                balance -= expenses
                print(f"Expense added: ${expenses:.2f}")
                save_balance(balance)
            except ValueError:
                print("Invalid input. Please enter a valid number.")
            input("Press Enter to continue...")

        elif choice == '3':
            print(f"Your current balance is: ${balance:.2f}")
            input("Press Enter to continue...")

        elif choice == '4':
            print("Exiting the program. Goodbye!")
            save_balance(balance)
            break

        else:
            print("Invalid choice. Please select a valid option (1-4).")
            input("Press Enter to continue...")  

if __name__ == "__main__":
    main()
