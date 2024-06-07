using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Area : Entity
{
    public int AreaId { get; set; }

    public int AreaTypeId { get; set; }

    public int AreaSize { get; set; }

    public virtual AreaType AreaType { get; set; } = null!;

    public virtual Spell? Spell { get; set; }
}
