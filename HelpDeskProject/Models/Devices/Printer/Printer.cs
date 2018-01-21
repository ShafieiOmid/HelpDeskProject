using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskProject.Models.Devices.Printer
{
    public class Printer : BaseEntity
    {
        public Printer() : base()
		{
        }

        [Display
            (Name = "Active")]
        public bool IsActive { get; set; }


        [Required
            (AllowEmptyStrings = false)]
        [Index
            (IsUnique = true)]
        public int HID { get; set; }

        [Required
            (AllowEmptyStrings = false)]
        public string PrinterModel { get; set; }
        [Required
            (AllowEmptyStrings = false)]
        public string PrinterType { get; set; }

        [Required
            (AllowEmptyStrings = false)]
        public string CartdridgeType { get; set; }

        public virtual IList<Printer> Printers { get; set; }
    }
}
