using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class MaterialType : Entity
{
    public int MaterialTypeId { get; set; }

    public string Label { get; set; } = null!;
}
