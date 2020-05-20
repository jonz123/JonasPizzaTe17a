using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericJonasTe17a
{
    class Program
    {

        static Random ran = new Random();

        static void Main(string[] args)
        {

            int score = 0;

            Console.WriteLine("You work at a pizzeria. Take orders and serve the pizza they want respectively.");
            Console.WriteLine("The pizzas will be served in two piles. Move the pizzas about to find the requested one.");
            Console.WriteLine("Finish the queue to win.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            Console.Clear();

            Queue<Customer> customerQueue = new Queue<Customer>(); //skapar kön
            int ogCustomers = ran.Next(6, 12); //slumpar så att det kan hamna mellan 8-12 kunder
            for (int i = 0; i < ogCustomers; i++)
            {
                Customer customer = new Customer();
                customerQueue.Enqueue(customer);
            }

            Stack<Pizza> stack1 = new Stack<Pizza>(); //skapar stack 1 av pizzor
            Stack<Pizza> stack2 = new Stack<Pizza>();
            for (int i = 0; i < 6; i++) //Lägger till 6 och 7 pizzor i respektive kö, alla av slumpade typer
            {
                Pizza pizza = new Pizza();
                stack1.Push(pizza);
            }
            for (int i = 0; i < 7; i++)
            {
                Pizza pizza = new Pizza();
                stack2.Push(pizza);
            }

            //Just nu riskerar det att den pizzan som kunden vill ha inte läggs till i stacken. 
            //Det går att motverka med att lägga till ett val där man ber om fler pizzor, eller att man flyttar kunden längst bak i kön.
            //Den koden ser ut: customerQueue.Enqueue(customerQueue.Peek()) och sedan customerQueue.Pop();

            string answer;

            while (customerQueue.Count() > 0) //Så länge det finns kunder, loopa
            {
                Console.WriteLine("Score: " + score);
                Console.WriteLine("There are " + customerQueue.Count + " customers in the queue.");
                Console.WriteLine();
                Console.WriteLine("The customer in front of you, " + customerQueue.Peek().name + ", wants a " + customerQueue.Peek().requestedPizza + ".");
                Console.WriteLine();
                if (stack1.Count > 0)
                {
                    Console.WriteLine("Atop the first pile is a " + stack1.Peek().pizzaType + "." + " (" + stack1.Count + " left)");
                }
                else
                {
                    Console.WriteLine("The first pile is empty.");
                }
                if (stack2.Count > 0)
                {
                    Console.WriteLine("Atop the second pile is a " + stack2.Peek().pizzaType + "." + " (" + stack2.Count + " left)");
                }
                else
                {
                    Console.WriteLine("The second pile is empty.");
                }
                
                Console.WriteLine();
                Console.WriteLine("Enter 1 to move the top of Stack 1 to Stack 2.");
                Console.WriteLine("Enter 2 to move the top of Stack 2 to Stack 1.");
                Console.WriteLine("Enter 3 if you have found the requested pizza.");
                Console.WriteLine();
                answer = Console.ReadLine();

                if (answer == "1") //Flyttar topen av Stack 1 till Stack 2 om det fortfarande finns pizzor i den
                {
                    if (stack1.Count > 0)
                    {
                        stack2.Push(stack1.Peek());
                        stack1.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Stack 1 is empty!");
                    }
                    
                }
                if (answer == "2") //Flyttar topen av Stack 2 till Stack 1 om det fortfarande finns pizzor i den
                {
                    if (stack2.Count > 0)
                    {
                        stack1.Push(stack2.Peek());
                        stack2.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Stack 1 is empty!");
                    }

                }
                if (answer == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine("Is one of the pizzas displayed correct?");
                    Console.WriteLine("If so, which pile?");
                    Console.WriteLine("If not, press enter.");
                    Console.WriteLine();
                    answer = Console.ReadLine();
                    if (answer == "1" || answer == "2") //Slippa krångel i metoden, svaren kan enbart vara "1" eller "2"
                    {
                        PizzaSelected();
                    }
                    else
                    {
                        //skip
                    }
                }

                Console.Clear();
            }
            Console.WriteLine("You won! There are no more customers left.");
            Console.WriteLine("Your final score was " + score + " points.");
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();

            void PizzaSelected() //Organiserad metod för att göra det mindre rörigt, jag gillar metoder
            {
                
                string chosenPizza = "";
                if (answer == "1")
                {
                    chosenPizza = stack1.Peek().pizzaType;
                    stack1.Pop();
                }
                else if (answer == "2")
                {
                    chosenPizza = stack2.Peek().pizzaType;
                    stack2.Pop();
                }

                if (chosenPizza == customerQueue.Peek().requestedPizza) //Om den valda stacken har den efterfrågade pizzan högst upp
                {
                    Console.WriteLine();
                    Console.WriteLine("That was the correct pizza!");
                    Console.WriteLine(customerQueue.Peek().name + " was very satisfied.");
                    Console.WriteLine("You recieve 100 points!");
                    score = score + 100;
                }
                else //Om den valda stacken INTE har den efterfrågade pizzan högst upp
                {
                    Console.WriteLine();
                    Console.WriteLine("That was the wrong pizza!!!");
                    Console.WriteLine(customerQueue.Peek().name + " was very angry.");
                    Console.WriteLine("You lose 100 points!");
                    score = score - 100;
                }
                customerQueue.Dequeue(); //Kunden går hem och njuter av sin fredagskväll. 
                //Jag tänkte även att det finns en chans att flera kunder kommer utifrån en spare queue av slumpartat antal. När spareQueue är slut så kommer inga fler kunder.

                int a = ran.Next(1, 4); //1-4 nya pizzor bakas
                Console.WriteLine();
                Console.WriteLine("In the meantime, " + a + " new pizzas were baked.");
                for (int i = 0; i < a; i++)
                {
                    Pizza pizza = new Pizza();
                    stack1.Push(pizza);
                }
                Console.WriteLine();
                Console.WriteLine("Press anything to continue.");
                Console.ReadKey();
            }
        }
    }
}
