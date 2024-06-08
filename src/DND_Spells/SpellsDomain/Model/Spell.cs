using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class Spell : Entity
{
    [Display(Name = "Книга")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int BookId { get; set; }

    [Display(Name = "Школа Магії")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int SchoolId { get; set; }

    [Display(Name = "Рівень")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int Level { get; set; }

    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public string Name { get; set; } = null!;

    [Display(Name = "Пояснення")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public string Description { get; set; } = null!;

    [Display(Name = "Ритуал?")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public bool Ritual { get; set; }

    [Display(Name = "Активація")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int CastingTimeTypeId { get; set; }

    [Display(Name = "Тривалість")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int? DurationId { get; set; }

    [Display(Name = "Відстань")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int RangeTypeId { get; set; }

    [Display(Name = "Площа")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int? AreaId { get; set; }

    [Display(Name = "V")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public bool Verbal { get; set; }

    [Display(Name = "S")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public bool Somatic { get; set; }

    [Display(Name = "M")]
    [Required(ErrorMessage = "Поле не має бути пустим")]
    public int Material { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual CastingTimeType CastingTimeType { get; set; } = null!;

    public virtual Duration? Duration { get; set; }

    public virtual RangeType RangeType { get; set; } = null!;

    public virtual SchoolOfMagic School { get; set; } = null!;
}
