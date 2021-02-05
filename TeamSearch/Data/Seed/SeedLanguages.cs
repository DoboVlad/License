using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamSearch.Models;

namespace TeamSearch.Data.Seed
{
    public class SeedLanguages
    {
        public static async Task SeedLang(DataContext context)
        {
            if(await context.LANGUAGES.AnyAsync()) return;

            var seedLanguages = await System.IO.File.ReadAllTextAsync("Data/LanguageSeedData.json");
            var languages = JsonSerializer.Deserialize<List<Language>>(seedLanguages);

            foreach (var language in languages)
            {
                context.LANGUAGES.Add(language);
            }

            await context.SaveChangesAsync();
        }
    }
}