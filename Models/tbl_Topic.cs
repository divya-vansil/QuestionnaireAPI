namespace QuestionnaireAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Topic
    {
        [Key]
        public long TopicID { get; set; }

        [Required]
        [StringLength(50)]
        public string TopicName { get; set; }
    }
}
