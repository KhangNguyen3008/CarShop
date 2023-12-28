using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarDealer
{
    public string DealerId { get; set; } = null!;

    public string DealerName { get; set; } = null!;

    public string? DealerAddress { get; set; }

    public string? DealerDetail { get; set; }

    public string? DealerLogo { get; set; }

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
