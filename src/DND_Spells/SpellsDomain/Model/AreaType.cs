using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class AreaType : Entity
{

    [Display(Name = "Фігура")]
    public string Label { get; set; } = null!;

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
}
