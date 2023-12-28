using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarProduct
{
    public string CarId { get; set; } = null!;

    public string CarName { get; set; } = null!;

    public string? CarDetail { get; set; }

    public string CarImage { get; set; } = null!;

    public int CatId { get; set; }

    public int Carprice { get; set; }

    public string OwnerId { get; set; } = null!;

    public string DealerId { get; set; } = null!;

    public virtual ICollection<CarOrder> CarOrders { get; set; } = new List<CarOrder>();

    public virtual CarCategory Cat { get; set; } = null!;

    public virtual CarDealer Dealer { get; set; } = null!;

    public virtual CarStoreOwner Owner { get; set; } = null!;
}
