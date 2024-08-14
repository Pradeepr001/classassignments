using System;
using System.Collections.Generic;

class Pizza
{
    // Private instance variables
    private string pizzaSize;
    private int cheeseToppings;
    private int pepperoniToppings;
    private int hamToppings;

    // Constructor
    public Pizza(string size, int cheese, int pepperoni, int ham)
    {
        pizzaSize = size;
        cheeseToppings = cheese;
        pepperoniToppings = pepperoni;
        hamToppings = ham;
    }

    // Getter and Setter for Pizza Size
    public string PizzaSize
    {
        get { return pizzaSize; }
        set { pizzaSize = value; }
    }

    // Getter and Setter for Cheese Toppings
    public int CheeseToppings
    {
        get { return cheeseToppings; }
        set { cheeseToppings = value; }
    }

    // Getter and Setter for Pepperoni Toppings
    public int PepperoniToppings
    {
        get { return pepperoniToppings; }
        set { pepperoniToppings = value; }
    }

    // Getter and Setter for Ham Toppings
    public int HamToppings
    {
        get { return hamToppings; }
        set { hamToppings = value; }
    }

    // Method to calculate the cost of the pizza
    public double CalcCost()
    {
        double baseCost = 0.0;

        // Determine base cost based on pizza size
        switch (pizzaSize.ToLower())
        {
            case "small":
                baseCost = 10.0;
                break;
            case "medium":
                baseCost = 12.0;
                break;
            case "large":
                baseCost = 14.0;
                break;
            default:
                throw new ArgumentException("Invalid pizza size.");
        }

        // Calculate cost for toppings
        double toppingCost = (cheeseToppings + pepperoniToppings + hamToppings) * 2.0;

        return baseCost + toppingCost;
    }

    // Method to get a description of the pizza
    public string GetDescription()
    {
        return $"Size: {pizzaSize}, Cheese Toppings: {cheeseToppings}, Pepperoni Toppings: {pepperoniToppings}, Ham Toppings: {hamToppings}";
    }
}

class Program
{
    static void Main()
    {
        // Create a list to store pizza records
        List<Pizza> pizzas = new List<Pizza>();

        // Add some pizza records
        pizzas.Add(new Pizza("Small", 2, 3, 1));
        pizzas.Add(new Pizza("Medium", 1, 2, 2));
        pizzas.Add(new Pizza("Large", 3, 1, 4));

        // Display details for each pizza
        foreach (var pizza in pizzas)
        {
            Console.WriteLine(pizza.GetDescription());
            Console.WriteLine($"Cost: ${pizza.CalcCost():0.00}");
            Console.WriteLine();
        }
    }
}
