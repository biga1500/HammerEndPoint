using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HammerEndPoint.Models
{
    public class ParticipantContext : DbContext
    {
        public ParticipantContext(DbContextOptions<ParticipantContext> options)
              : base(options)
        {
        }

        public DbSet<Participant> Parcticipants { get; set; }
    }
}
