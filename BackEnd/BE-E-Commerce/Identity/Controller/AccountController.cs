using BE_E_Commerce.Identity.DTOs;
using BE_E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_E_Commerce.Identity.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController: ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AccountController(ILogger<AccountController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _unitOfWork.AccountRepository.All();
        if (accounts == null)
        {
            return NotFound();
        }
        return Ok(accounts);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(AccountRequest accountRequest)
    {
        if (ModelState.IsValid)
        {
            var account = new Account()
            {
                UserName = accountRequest.UserName,
                Password = accountRequest.Password,
            };
            await _unitOfWork.AccountRepository.Add(account);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetItem", new { id = account.Id }, accountRequest);
        }
        return new JsonResult("Something went wrong") { StatusCode = 500 };
    }
}