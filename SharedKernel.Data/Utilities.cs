using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedKernel.Interfaces;
using System;

namespace SharedKernel.Data
{
    public static class Utilities
    {
        public static void ApplyStateUsingIsKeySet(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public static void FixState(this DbContext context, IEntity item)
        {
            context.ChangeTracker.TrackGraph(item, e => ApplyStateUsingIsKeySet(e.Entry));
        }
    }
}
