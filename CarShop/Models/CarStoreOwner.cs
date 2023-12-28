using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarStoreOwner
{
    public string OwnerId { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public string? OwnerDetail { get; set; }

    public string? OwnerAddress { get; set; }

    public string OwnerPassword { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
