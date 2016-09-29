using Qx.Contents.Configs;

namespace Qx.Contents.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContentsContext : DbContext
    {
        public ContentsContext()
            : base(Setting.ConnectionString)
        {
        }
        public virtual DbSet<ContentColumnDesign> ContentColumnDesigns { get; set; }
        public virtual DbSet<ContentColumnValue> ContentColumnValues { get; set; }
        public virtual DbSet<ContentTableDesign> ContentTableDesigns { get; set; }
        public virtual DbSet<ContentTableQuery> ContentTableQueries { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<PageControlType> PageControlTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.CCD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.DT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.PCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.Seq)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.IsPk)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnDesign>()
                .Property(e => e.DefValue)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnValue>()
                .Property(e => e.CCV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnValue>()
                .Property(e => e.CCD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnValue>()
                .Property(e => e.ColumnValue)
                .IsUnicode(false);

            modelBuilder.Entity<ContentColumnValue>()
                .Property(e => e.RelationKeyValue)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableDesign>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableDesign>()
                .Property(e => e.CT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableDesign>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableDesign>()
                .HasMany(e => e.ContentColumnDesigns)
                .WithOptional(e => e.ContentTableDesign)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ContentTableDesign>()
                .HasMany(e => e.ContentTableQueries)
                .WithOptional(e => e.ContentTableDesign)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ContentTableQuery>()
                .Property(e => e.CTQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableQuery>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTableQuery>()
                .Property(e => e.SqlQuery)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .Property(e => e.CT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .Property(e => e.FatherID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .HasMany(e => e.ContentTableDesigns)
                .WithOptional(e => e.ContentType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DataType>()
                .Property(e => e.DT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DataType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<DataType>()
                .HasMany(e => e.ContentColumnDesigns)
                .WithOptional(e => e.DataType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PageControlType>()
                .Property(e => e.PCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PageControlType>()
                .Property(e => e.PCT_Name)
                .IsUnicode(false);

            modelBuilder.Entity<PageControlType>()
                .HasMany(e => e.ContentColumnDesigns)
                .WithOptional(e => e.PageControlType)
                .WillCascadeOnDelete();
        }
    }
}
