using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskProject.Models.Devices.Printer
{
    public class Cartridge : BaseEntity
    {
        public Cartridge():base()
        { }
        [Display
           (Name = "Active")]
        public bool IsActive { get; set; }


        [Required
            (AllowEmptyStrings = false)]
        [Index
            (IsUnique = true)]
        public int CID { get; set; }
    }
}