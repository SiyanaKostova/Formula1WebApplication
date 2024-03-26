using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.SeedDb
{
    internal class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            var data = new SeedData();

            builder.HasData(new Pilot[] { data.MaxVerstappen, data.CharlesLeclerc, data.SergioPerez,
                data.CarlosSainz, data.OscarPiastri, data.LandoNorris, data.GeorgeRussell, data.FernandoAlonso,
                data.LanceStroll, data.LewisHamilton, data.YukiTsunoda, data.NicoHulkenberg, data.KevinMagnussen,
                data.AlexAlbon, data.GuanyuZhou, data.DanielRicciardo, data.EstebanOcon, data.PierreGasly,
                data.ValtteriBottas, data.LoganSargeant});
        }
    }
}
