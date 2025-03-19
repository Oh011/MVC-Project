using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entites.Common.Enums;
using Project.DAL.Entites.Employees;

namespace Project.DAL.prestance.Data.Configurations.Employees
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {


        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)").IsRequired();


            builder.Property(E => E.Salary).HasColumnType("decimal(8,3)");

            builder.Property(E => E.Address).HasColumnType("nvarchar(100)");

            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETDATE()");


            builder.Property(employee => employee.CreatedOn).HasDefaultValueSql("GETDATE()");


            builder.Property(E => E.Gender).HasConversion(


                G => G.ToString(),
                G => (Gender)Enum.Parse(typeof(Gender), G)

                );


            builder.Property(E => E.EmployeeType).HasConversion(



                ET => ET.ToString(),
                ET => (EmployeeType)Enum.Parse(typeof(EmployeeType), ET)

                );
        }
    }
}
