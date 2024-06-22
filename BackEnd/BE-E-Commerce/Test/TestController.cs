using BE_E_Commerce.Models;
using DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_E_Commerce.Test;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ECommerceContext _eCommerceContext;

    public TestController(ECommerceContext eCommerceContext)
    {
        _eCommerceContext = eCommerceContext;
    }
    
    [HttpGet]
    public async Task<string> GetAllAccount()
    {
        var test = await _eCommerceContext.Accounts.ToListAsync();
        if (test.Count > 0)
        {
            return "Success";
        }
        return "Failed";
    }
}