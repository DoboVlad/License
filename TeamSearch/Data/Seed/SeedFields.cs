using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamSearch.Models;

namespace TeamSearch.Data.Seed
{
    public class Seed
    {
        public static async Task SeedFields(DataContext context)
        {
            if(await context.FIELDS.AnyAsync()) return;

            var fieldsData = await System.IO.File.ReadAllTextAsync("Data/FieldSeedData.json");
            var fields = JsonSerializer.Deserialize<List<Field>>(fieldsData);

            foreach(var field in fields)
            {
                context.FIELDS.Add(field);
            }
            
            await context.SaveChangesAsync();
        }
    }
}