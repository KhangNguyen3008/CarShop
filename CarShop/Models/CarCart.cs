using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarCart
{
    public string CarId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public int Price { get; set; }

    public int Quanity { get; set; }

    public virtual CarOrder Order { get; set; } = null!;
}
