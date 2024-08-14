
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<Product> products = new List<Product>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Who are you? (Admin/Customer)");
                string role = Console.ReadLine().ToLower();

                if (role == "admin")
                {
                    AdminActions();
                }
                else if (role == "customer")
                {
                    CustomerActions();
                }
                else
                {
                    Console.WriteLine("Invalid role. Please enter 'Admin' or 'Customer'.");
                }
            }
        }

        static void AdminActions()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Products");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                AddProduct();
            }
            else if (choice == 2)
            {
                DisplayProducts();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void CustomerActions()
        {
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. Order Product");
            Console.WriteLine("2. Get Bill");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                OrderProduct();
            }
            else if (choice == 2)
            {
                GetBill();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter Product Code: ");
            string pCode = Console.ReadLine();

            Console.Write("Enter Product Name: ");
            string pName = Console.ReadLine();

            Console.Write("Enter Quantity in Stock: ");
            int qtyInStock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Discount Allowed: ");
            double discountAllowed = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            products.Add(new Product(pCode, pName, qtyInStock, discountAllowed, brand));
            Console.WriteLine("Product added successfully.");
        }

        static void DisplayProducts()
        {
            Console.WriteLine("Product List:");
            foreach (var product in products)
            {
                product.DisplayDetails();
                Console.WriteLine();
            }
        }

        static void OrderProduct()
        {
            Console.Write("Enter Product Name to Order: ");
            string pname = Console.ReadLine();

            var product = products.Find(p => p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                product.DisplayDetails();
                Console.Write("Enter Quantity to Order: ");
                int qty = Convert.ToInt32(Console.ReadLine());

                if (qty <= product.QtyInStock)
                {
                    product.QtyInStock -= qty;
                    Console.WriteLine($"Order placed for {qty} units of {product.PName}.");
                }
                else
                {
                    Console.WriteLine("Insufficient stock.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void GetBill()
        {
            double totalAmount = 0;

            Console.Write("Enter Product Name to Purchase: ");
            string pname = Console.ReadLine();

            var product = products.Find(p => p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                product.DisplayDetails();
                Console.Write("Enter Quantity to Purchase: ");
                int qty = Convert.ToInt32(Console.ReadLine());

                if (qty <= product.QtyInStock)
                {
                    double pricePerUnit = 0; // Set actual price per unit for calculation
                    Console.Write("Enter Price per Unit: ");
                    pricePerUnit = Convert.ToDouble(Console.ReadLine());

                    double discountPrice = product.CalculateDiscountedPrice(pricePerUnit);
                    double amount = discountPrice * qty;
                    totalAmount += amount;

                    Console.WriteLine($"Amount for {qty} units of {product.PName} at discounted rate: {amount:0.00}");
                }
                else
                {
                    Console.WriteLine("Insufficient stock.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            // Apply 50% discount
            totalAmount *= 0.50;

            // Ensure minimum bill amount is Rs. 100
            if (totalAmount < 100)
            {
                totalAmount = 100;
            }

            Console.WriteLine($"Total Amount (after discount and minimum amount check): {totalAmount:0.00}");
        }
    }
