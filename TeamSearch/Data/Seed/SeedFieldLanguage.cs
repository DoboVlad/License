using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeamSearch.Data.Seed
{
    public class SeedFieldLanguage
    {
        public static async Task SeedFieldLang(DataContext context)
        {
            if(await context.FIELDS.AnyAsync()) return;
        }
    }
}