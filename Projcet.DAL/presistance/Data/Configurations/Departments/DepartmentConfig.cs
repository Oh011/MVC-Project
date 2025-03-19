using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entites.Departments;

namespace Project.DAL.prestance.Data.Configurations.Departments
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {


            builder.Property(department => department.Id).UseIdentityColumn(10, 5);


            builder.Property(D => D.Name).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(D => D.Code).HasColumnType("nvarchar(20)").IsRequired();



            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");


            builder.Property(department => department.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.HasMany(D => D.Employees)
             .WithOne(E => E.Department)
             .HasForeignKey(E => E.DepartmentId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
