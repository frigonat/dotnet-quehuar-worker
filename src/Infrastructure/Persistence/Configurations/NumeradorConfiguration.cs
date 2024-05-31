using dotnet_quehuar_worker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Infrastructure.Persistence.Configurations
{
    public class NumeradorConfiguration
    {
        public void Configure(EntityTypeBuilder<Numerador> builder)
        {
            builder.ToTable("numerador");
            builder.HasKey(e => e.centroEmisor);
            builder.Property(e => e.centroEmisor);
            builder.Property(e => e.ultimoNumero);
            builder.Property(e => e.fechaHoraUltimoNumero);
        }
    }
}

