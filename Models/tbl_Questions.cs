namespace QuestionnaireAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Questions
    {
        [Key]
        public long QuestionID { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public long TopicID { get; set; }
    }
}
