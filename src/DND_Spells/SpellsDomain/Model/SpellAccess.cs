using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class SpellAccess : Entity
{
    public int ClassId { get; set; }

    public int SpellId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
