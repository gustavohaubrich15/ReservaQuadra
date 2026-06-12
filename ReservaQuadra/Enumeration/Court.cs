using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReservaQuadra.Enumeration
{
    public enum Court
    {
        [Display(Name = "Quadra Grand Slam")]
        GrandSlam = 1,
        [Display(Name = "Quadra Masters 1000")]
        Masters,
        [Display(Name = "Quadra Championship")]
        Championship,
    }
}
