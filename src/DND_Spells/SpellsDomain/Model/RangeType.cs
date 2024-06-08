using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class RangeType : Entity
{
    [Display(Name = "Кількість")]
    [Required(ErrorMessage = "Не може бути пустим")]
    public int Value { get; set; }

    [Display(Name = "Одиниці вимірювання")]
    [Required(ErrorMessage = "Не може бути пустим")]
    public string Label { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
