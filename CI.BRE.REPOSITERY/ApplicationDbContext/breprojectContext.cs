using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CI.BRE.REPOSITERY.Entities;

namespace CI.BRE.REPOSITERY.ApplicationDbContext
{
    public partial class breprojectContext : DbContext
    {
        public breprojectContext()
        {
        }

        public breprojectContext(DbContextOptions<breprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpsBrArgumentValue> SpsBrArgumentValues { get; set; } = null!;
        public virtual DbSet<SpsBrClassifier> SpsBrClassifiers { get; set; } = null!;
        public virtual DbSet<SpsBrClassifierMetadatum> SpsBrClassifierMetadata { get; set; } = null!;
        public virtual DbSet<SpsBrSeverity> SpsBrSeverities { get; set; } = null!;
        public virtual DbSet<SpsClassifierBrMapping> SpsClassifierBrMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=breproject;Username=postgres;Password=upendra123;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpsBrArgumentValue>(entity =>
            {
                entity.HasKey(e => e.BrKey)
                    .HasName("sps_br_argument_value_pkey");

                entity.ToTable("sps_br_argument_value");

                entity.Property(e => e.BrKey).HasColumnName("br_key");

                entity.Property(e => e.ArgValue1)
                    .HasMaxLength(80)
                    .HasColumnName("arg_value_1");

                entity.Property(e => e.ArgValue2)
                    .HasMaxLength(40)
                    .HasColumnName("arg_value_2");

                entity.Property(e => e.ArgumentType)
                    .HasMaxLength(20)
                    .HasColumnName("argument_type");

                entity.Property(e => e.ArgumentValue)
                    .HasColumnName("argument_value")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(40)
                    .HasColumnName("column_name");

                entity.Property(e => e.ErrorDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("error_description");

                entity.Property(e => e.EtlRule)
                    .HasMaxLength(1)
                    .HasColumnName("etl_rule");

                entity.Property(e => e.Expression)
                    .HasColumnName("expression")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.InputArgV2)
                    .HasColumnName("input_arg_v2")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.IsBre2).HasColumnName("is_bre2");

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .HasColumnName("operator");

                entity.Property(e => e.ProvinceState)
                    .HasMaxLength(20)
                    .HasColumnName("province_state");

                entity.Property(e => e.RowChangedBy)
                    .HasMaxLength(100)
                    .HasColumnName("row_changed_by");

                entity.Property(e => e.RowChangedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_changed_date");

                entity.Property(e => e.RowCreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("row_created_by");

                entity.Property(e => e.RowCreatedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_created_date");

                entity.Property(e => e.RuleRange).HasColumnName("rule_range");

                entity.Property(e => e.RuleType)
                    .HasMaxLength(20)
                    .HasColumnName("rule_type");

                entity.Property(e => e.RuleVersion)
                    .HasColumnName("rule_version")
                    .HasDefaultValueSql("'0.0.0'::text");

                entity.Property(e => e.RunOrder).HasColumnName("run_order");

                entity.Property(e => e.Severity).HasColumnName("severity");

                entity.Property(e => e.TableName)
                    .HasMaxLength(40)
                    .HasColumnName("table_name");

                entity.Property(e => e.UiRule)
                    .HasMaxLength(1)
                    .HasColumnName("ui_rule");

                entity.HasOne(d => d.SeverityNavigation)
                    .WithMany(p => p.SpsBrArgumentValues)
                    .HasForeignKey(d => d.Severity)
                    .HasConstraintName("SEVERITY_FK");
            });

            modelBuilder.Entity<SpsBrClassifier>(entity =>
            {
                entity.ToTable("sps_br_classifier");

                entity.HasIndex(e => new { e.Dataset, e.ClassifierId }, "table_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClassifierId).HasColumnName("classifier_id");

                entity.Property(e => e.Dataset)
                    .HasMaxLength(200)
                    .HasColumnName("dataset");
            });

            modelBuilder.Entity<SpsBrClassifierMetadatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sps_br_classifier_metadata");

                entity.Property(e => e.AttName)
                    .HasMaxLength(200)
                    .HasColumnName("att_name");

                entity.Property(e => e.AttValue)
                    .HasMaxLength(200)
                    .HasColumnName("att_value");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.HasOne(d => d.Rel)
                    .WithMany()
                    .HasForeignKey(d => d.RelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sps_classifier_br_key_fk");
            });

            modelBuilder.Entity<SpsBrSeverity>(entity =>
            {
                entity.HasKey(e => e.Severity)
                    .HasName("sps_br_severity_pkey");

                entity.ToTable("sps_br_severity");

                entity.Property(e => e.Severity)
                    .ValueGeneratedNever()
                    .HasColumnName("severity");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.SeverityType)
                    .HasMaxLength(40)
                    .HasColumnName("severity_type");
            });

            modelBuilder.Entity<SpsClassifierBrMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sps_classifier_br_mapping");

                entity.Property(e => e.BrKey).HasColumnName("br_key");

                entity.Property(e => e.ClassifierId).HasColumnName("classifier_id");

                entity.HasOne(d => d.BrKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BrKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sps_classifier_br_key_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
