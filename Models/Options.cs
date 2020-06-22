namespace QuestionnaireAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Options : DbContext
    {
        public Options()
            : base("name=Options")
        {
        }

        public virtual DbSet<tbl_Options> tbl_Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Options>()
                .Property(e => e.OptionText)
                .IsUnicode(false);
        }
    }
}
