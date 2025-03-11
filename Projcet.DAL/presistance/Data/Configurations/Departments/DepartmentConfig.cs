using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projcet.DAL.Entites.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projcet.DAL.prestance.Data.Configurations.Departments
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
          

            builder.Property(department=>department.Id).UseIdentityColumn(10,5);


            builder.Property(D => D.Name).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(D => D.Code).HasColumnType("nvarchar(20)").IsRequired();



            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");


            builder.Property(department => department.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
