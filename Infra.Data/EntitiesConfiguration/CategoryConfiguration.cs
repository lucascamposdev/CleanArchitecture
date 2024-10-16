﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Doces"),
                new Category(2, "Salgados"),
                new Category(3, "Bebidas")
            );
        }
    }
}
