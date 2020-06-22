namespace QuestionnaireAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Questions : DbContext
    {
        public Questions()
            : base("name=Questions")
        {
        }

        public virtual DbSet<tbl_Questions> tbl_Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Questions>()
                .Property(e => e.QuestionText)
                .IsUnicode(false);
        }
    }
}
