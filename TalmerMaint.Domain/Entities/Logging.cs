namespace TalmerMaint.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Logging : DbContext
    {
        public Logging()
            //: base("name=EFDbContext")
            : base("name=TalmerLoggingDbEntities")
        {
        }

        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<NLog_Error> NLog_Error { get; set; }
        public virtual DbSet<vw_aspnet_WebEvents_extended> vw_aspnet_WebEvents_extended { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_aspnet_WebEvents_extended>()
                .Property(e => e.EventId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vw_aspnet_WebEvents_extended>()
                .Property(e => e.EventSequence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<vw_aspnet_WebEvents_extended>()
                .Property(e => e.EventOccurrence)
                .HasPrecision(19, 0);
        }
    }
}
