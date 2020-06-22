namespace QuestionnaireAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Topic : DbContext
    {
        public Topic()
            : base("name=Topic")
        {
        }

        public virtual DbSet<tbl_Topic> tbl_Topic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Topic>()
                .Property(e => e.TopicName)
                .IsUnicode(false);
        }
    }
}
