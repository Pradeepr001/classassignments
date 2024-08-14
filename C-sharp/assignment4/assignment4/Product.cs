using System;
using System.Collections.Generic;

class Product
{
    public string PCode { get; }
    public string PName { get; set; }
    public int QtyInStock { get; set; }
    public double DiscountAllowed { get; set; }
    public string Brand { get; set; }

    public Product(string pCode, string pName, int qtyInStock, double discountAllowed, string brand)
    {
        PCode = pCode;
        PName = pName;
        QtyInStock = qtyInStock;
        DiscountAllowed = discountAllowed;
        Brand = brand;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Product Code : {PCode}");
        Console.WriteLine($"Product Name : {PName}");
        Console.WriteLine($"Quantity in Stock : {QtyInStock}");
        Console.WriteLine($"Discount Allowed : {DiscountAllowed}%");
        Console.WriteLine($"Brand : {Brand}");
    }

    public double CalculateDiscountedPrice(double price)
    {
        return price * (1 - DiscountAllowed / 100);
    }
}
