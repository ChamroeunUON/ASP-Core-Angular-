using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core.Models;
using ASP_Angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers
{
    public class FeatureController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeatureController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public VegaDbContext Context => context;

        public IMapper Mapper => mapper;

    [HttpGet("/api/features")]
    public async Task<IEnumerable<KeyValuePareResource>> GetMakes()
    {
         var features = await context.Features.ToListAsync();

      return mapper.Map<List<Feature>, List<KeyValuePareResource>>(features); 
    }
    
    }
}