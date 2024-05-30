using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal SHIPPING_COST_USA = 5.00m;
    private const decimal SHIPPING_COST_NON_USA = 35.00m;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? SHIPPING_COST_USA : SHIPPING_COST_NON_USA;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();

        foreach (var product in _products)
        {
            packingLabel.AppendLine($"{product.GetName()} ({product.GetProductId()})");
        }

        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}