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

        [Display
           (Name = "Drum")]
        public bool DrumReplaced { get; set; }


        [Display
           (Name = "Maggnet")]
        public bool MaggnetReplaced { get; set; }


        [Display
           (Name = "Blade")]
        public bool BladeReplaced { get; set; }


        [Display
           (Name = "Foam")]
        public bool FoamReplaced { get; set; }


        [Display
           (Name = "Tank")]
        public bool TankReplaced { get; set; }


        [Required
            (AllowEmptyStrings = false)]
        [Index
            (IsUnique = true)]
        public int CID { get; set; }


        [Required
            (AllowEmptyStrings = false)]
        public string PrinterModel { get; set; }


        [Required
            (AllowEmptyStrings = false)]
        public string CartridgeModel { get; set; }

        [DisplayFormat
            (DataFormatString = "{0: yyyy/MM/dd}",NullDisplayText = "yyyy/MM/dd")]
        public String DeliverTime { get; set; }
        
        public DateTime CommitTime { get; set; }


        public virtual IList<Cartridge> Cartridges { get; set; }
    }
}