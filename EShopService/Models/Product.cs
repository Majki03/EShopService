﻿namespace EShopService.Models;

public class Product : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Ean { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Sku { get; set; } = default!;
}
