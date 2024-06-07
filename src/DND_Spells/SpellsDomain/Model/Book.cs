using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class Book : Entity
{
    [Display(Name = "Назва")]
    public string Title { get; set; } = null!;

    [Display(Name = "Скорочення")]
    public string Short { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
