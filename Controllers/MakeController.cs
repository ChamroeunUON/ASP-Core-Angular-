using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Models;
using ASP_Angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers
{
    public class MakeController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakeController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public VegaDbContext Context => context;

        public IMapper Mapper => mapper;

    [HttpGet("/api/makes")]
    public async Task<IEnumerable<MakeResource>> GetMakes()
    {
        var makes = await context.Makes.Include(m => m.Models).ToListAsync();
        return mapper.Map<List<Make>, List<MakeResource>>(makes);
    }
    


    
    [HttpGet("/api/listData")]
    public IEnumerable<string> ListData()
    {
        var li = new List<string>();
        li.Add("Kok");
        li.Add("Kok");
        li.Add("Kok");
        li.Add("Kok");
        return li;
    }
    }
}