namespace BE_E_Commerce.Identity.DTOs;

public class AccountRequest
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}