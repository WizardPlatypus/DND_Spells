using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class Spell : Entity
{
    public int BookId { get; set; }

    public int SchoolId { get; set; }

    [Display(Name = "Рівень")]
    public int Level { get; set; }

    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;

    [Display(Name = "Пояснення")]
    public string Description { get; set; } = null!;

    [Display(Name = "Ритуал?")]
    public bool Ritual { get; set; }

    public int CastingTimeTypeId { get; set; }

    public int? DurationId { get; set; }

    public int RangeTypeId { get; set; }

    public int? AreaId { get; set; }

    [Display(Name = "V")]
    public bool Verbal { get; set; }

    [Display(Name = "S")]
    public bool Somatic { get; set; }

    [Display(Name = "M")]
    public int Material { get; set; }

    [Display(Name = "Площа")]
    public virtual Area? Area { get; set; }

    [Display(Name = "Книга")]
    public virtual Book Book { get; set; } = null!;

    [Display(Name = "Активація")]
    public virtual CastingTimeType CastingTimeType { get; set; } = null!;

    [Display(Name = "Тривалість")]
    public virtual Duration? Duration { get; set; }

    [Display(Name = "Відстань")]
    public virtual RangeType RangeType { get; set; } = null!;

    [Display(Name = "Школа Магії")]
    public virtual SchoolOfMagic School { get; set; } = null!;
}
