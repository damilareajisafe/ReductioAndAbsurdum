public class Product
{
    public int ProductTypeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime StockDate { get; set; }
    public int DaysOnShelf
    {
        get
        {
            return (int)(DateTime.Now - StockDate).TotalDays;
        }
    }
}

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
}