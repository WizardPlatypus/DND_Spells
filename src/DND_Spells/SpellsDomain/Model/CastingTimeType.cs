using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class CastingTimeType : Entity
{
    [Display(Name = "Кількість")]
    public int Value { get; set; }

    [Display(Name = "Одиниці вимірювання")]
    public string Label { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
