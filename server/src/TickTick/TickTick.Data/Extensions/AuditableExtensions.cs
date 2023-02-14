using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTick.Models;

namespace TickTick.Data.Extensions
{
    public static class AuditableExtensions
    {

        public static void AddAuditableInfo(this DbContext ctx)
        {
            // PUT, POST en DELETE
            // BASEAUDITABLEENTITY

            //var entries = ctx.ChangeTracker
            //    .Entries()
            //    .Where(e => e.Entity is BaseAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            var entries = ctx.ChangeTracker
                .Entries<BaseAuditableEntity>()
                .Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified));


            foreach (var entry in entries)
            {
                /*if(entry.State is EntityState.Added)
                {
                    ((BaseAuditableEntity)entry.Entity).CreatedAt = DateTime.Now;
                }*/

                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
