using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class SchoolOfMagic : Entity
{
    public string Label { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
