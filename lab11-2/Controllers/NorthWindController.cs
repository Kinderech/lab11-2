using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab11_2.Controllers;

[ApiController]
[Route("[controller]")]
public class NorthWindController : ControllerBase
{
    private readonly ILogger<NorthWindController> _logger;
    private ApplicationContext _dbContext;

    public NorthWindController(ILogger<NorthWindController> logger, ApplicationContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    [HttpGet("NorthWindRegions")]
    public IEnumerable<Region> GetNorthWindList()
    {
        return _dbContext.Region.ToList();
        
    }
    
    [HttpGet("getNorthWindRegion")]
    public Region GetNorthWindRegion(int regionId)
    {
        return _dbContext.Region.Where(r => r.RegionID ==  regionId).FirstOrDefault();
    }
    
    [HttpPost("addNorthWindRegion")]
    public void AddNorthWindRegion(Region region)
    { 
        _dbContext.Region.Add(region);
        _dbContext.SaveChanges();
    }
    
    [HttpPut("upadteNorthWindRegion")]
    public void UpdateNorthWindRegion(Region region)
    { 
        var savedRegion = _dbContext.Region.Where(r => r.RegionID ==  region.RegionID).FirstOrDefault();
        if (savedRegion == null)
        {
            _dbContext.Region.Add(region);   
            return;
        }

        savedRegion.RegionDescription = region.RegionDescription;
        _dbContext.Region.Update(savedRegion);
        _dbContext.SaveChanges();
    }
    
    [HttpDelete("deleteNorthWindRegion")]
    public void AddNorthWindRegion(int regionId)
    {
        var document = _dbContext.Region.Where(r => r.RegionID ==  regionId).FirstOrDefault();
        if (document != null)
        {
            _dbContext.Region.Remove(document);
            _dbContext.SaveChanges();
        }
    }
}