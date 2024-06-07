using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class DurationType : Entity
{
    [Display(Name = "Кількість")]
    public int Value { get; set; }

    [Display(Name = "Одиниці вимірювання")]
    public string Label { get; set; } = null!;

    public virtual ICollection<Duration> Durations { get; set; } = new List<Duration>();
}
