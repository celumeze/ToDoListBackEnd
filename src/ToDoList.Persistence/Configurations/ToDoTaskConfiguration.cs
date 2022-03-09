using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Persistence.Configurations
{
    public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            builder.Property(t => t.LastModifiedBy)
                .HasMaxLength(100);
        }
    }
}
