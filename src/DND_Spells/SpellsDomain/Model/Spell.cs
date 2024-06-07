﻿using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Spell : Entity
{
    public int BookId { get; set; }

    public int SchoolId { get; set; }

    public int Level { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Ritual { get; set; }

    public int CastingTimeTypeId { get; set; }

    public int? DurationId { get; set; }

    public int RangeTypeId { get; set; }

    public int? AreaId { get; set; }

    public bool Verbal { get; set; }

    public bool Somatic { get; set; }

    public int Material { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual CastingTimeType CastingTimeType { get; set; } = null!;

    public virtual Duration? Duration { get; set; }

    public virtual RangeType RangeType { get; set; } = null!;

    public virtual SchoolOfMagic School { get; set; } = null!;
}
