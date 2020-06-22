namespace QuestionnaireAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Options
    {
        [Key]
        public long OptionID { get; set; }

        [Required]
        public string OptionText { get; set; }

        public long QuestionID { get; set; }

        public bool IsAnswer { get; set; }
    }
}
