using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Attack : Entity
{
    public int SpellId { get; set; }

    public byte AttackTypeId { get; set; }

    public virtual AttackType AttackType { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
