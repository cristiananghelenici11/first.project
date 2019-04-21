using System.ComponentModel.DataAnnotations;

namespace TagHelper.Models
{
    public enum DayTime
    {
        [Display(Name ="Утро")]
        Morning,
        [Display(Name = "День")]
        Afternoon,
        [Display(Name = "Вечер")]
        Evening,
        [Display(Name = "Ночь")]
        Night
    }
}