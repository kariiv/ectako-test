using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EctakoTest.Infrastructure.Data.ValueGenerators;


public class TimeNowGenerator : ValueGenerator<DateTime>
{
    public override DateTime Next(EntityEntry entry)
    {
        if (entry == null)
            throw new ArgumentNullException(nameof(entry));

        return DateTime.Now;
    }

    public override bool GeneratesTemporaryValues { get; }
}