using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VideoplayerProject.API.Models.Input;
using VideoplayerProject.API.Models.Output;
using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Domain.Interfaces;

namespace VideoplayerProject.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserDbContext _dbContext;
    private readonly IUserRepository _userRepository;
    private bool loginEnabled = false;

    const string Issuer = "ReceptApp";
    const string Audience = "ReceptAppAudience";
    const string SecretKey = "secretkeyshouldbehere";
    public UserController(UserDbContext dbContext, IUserRepository userRepo)
    {
        _dbContext = dbContext;
        _userRepository = userRepo;
    }

    [HttpPost("register")]
    public IActionResult Register(UserInputDTO user)
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public ActionResult<UserOutputDTO> Login([FromBody]UserOutputDTO user)
    {
        if (_userRepository.Login(user.Username, user.Password) || !loginEnabled)
        {
            var token = GenerateToken(user);
            return Ok(new { Message = "Login successful", Token = token });
        }
        return Unauthorized(new { Message = "Invalid username or password" });
    }

    private string GenerateToken(UserOutputDTO user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Username.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

