using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskProject.Models
{
    public class RepairModel : BaseEntity
    {

        public RepairModel() : base()
        { }
        [Display
        (Name = "Cost")]
        public bool HasCost { get; set; }



        [Display
        (Name = "Replace")]
        public bool HasReplaced { get; set; }



        [Required
            (AllowEmptyStrings = false, ErrorMessage = "Hardware Department Code is required")]
        [Index
            (IsUnique = true)]
        public int HID { get; set; }


        [Required
            (AllowEmptyStrings = false, ErrorMessage = "Proberty Code is required")]
        [Index
            (IsUnique = true)]
        public int PID { get; set; }



        [Required
            (AllowEmptyStrings = false,ErrorMessage = "Please Insert the Model")]
        public string Model { get; set; }



        [Required
              (AllowEmptyStrings = false, ErrorMessage = "Please Select Category")]
        public string Category { get; set; }



        [Required
            (AllowEmptyStrings = false, ErrorMessage = "Receipt Code is required")]
        public int ReceiptID { get; set; }


        
        public DateTime CommitTime { get;set;}




        public virtual IList<RepairModel> Repairs { get; set; }

    }
}