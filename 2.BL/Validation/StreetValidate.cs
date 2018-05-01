using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL.Validation
{
    [MetadataType(typeof(StreetValidate))]
    public partial class Street
    {
    }

    public partial class StreetValidate
    {
        [Required]
        [Display(Name = "שם עיר")]
        public string streetName { get; set; }
    }
}
