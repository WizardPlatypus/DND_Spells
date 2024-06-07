using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class Duration : Entity
{
    public int DurationTypeId { get; set; }

    [Display(Name = "Концентрація?")]
    public bool Concentration { get; set; }

    [Display(Name = "Довічно?")]
    public bool Dismissable { get; set; }

    public virtual DurationType DurationType { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
