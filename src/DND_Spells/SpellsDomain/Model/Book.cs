using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Book : Entity
{
    public string Title { get; set; } = null!;

    public string Short { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
