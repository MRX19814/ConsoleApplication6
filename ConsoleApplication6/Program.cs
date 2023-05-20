using System;
using System.Collections.Generic;

abstract class Delivery // обстрактный класс
{
    public string Address { get; set; }
}

class HomeDelivery : Delivery //  наследуется от базового класса Delivery
{
    public string CourierName { get; set; }
}

class PickPointDelivery : Delivery // наследуется от базового класса Delivery
{
    public string CompanyName { get; set; }
    public string PickupPoint { get; set; }
}

class ShopDelivery : Delivery // наследуется от базового класса Delivery
{
    public string ShopName { get; set; }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Order <TDelivery> where TDelivery : Delivery // используются конструкторы с параметрами, класс использует обобщение TDelivery, содержит объект класса TDelivery в свойстве Delivery, а также список объектов класса Product в свойстве Products
{
    public TDelivery Delivery { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }

    public Order(TDelivery delivery, int number, string description)
    {
        Delivery = delivery;
        Number = number;
        Description = description;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price;
        }
        return totalPrice;
    }
}

class Address // в классе переопределен метод ToString, используются конструкторы с параметрами
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }

    public Address(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {PostalCode}";
    }
}