using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamSearch.Data;
using TeamSearch.DTO;
using TeamSearch.Models;

namespace TeamSearch.Controllers
{
    public class FieldsController : BaseApiController
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public FieldsController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("fields")]
        public async Task<ActionResult<Field>> getFields()
        {
            var fields = await context.FIELDS
            .Include(x => x.fieldLanguages)
            .ThenInclude(x => x.Language)
            .ToListAsync();

            var fieldToReturn = mapper.Map<IEnumerable<FieldDTO>>(fields);

            return Ok(fieldToReturn);
        }
    }
}