using ProcurementService.API.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Schemes.Security.Users;
using ProcurementService.API.DAL.Schemes.Security.Roles;
using ProcurementService.API.DAL.Schemes.Security.Users.UserInteraction;

namespace ProcurementService.API.Controllers.Authorization
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Test")]
        public async Task<ActionResult> Register([FromBody] UserRequest data)
        {
            return new JsonResult(new
            {
                success = "Пользователь зарегестрирован!"
            });
        }


        //[HttpPost("Register")]
        //public async Task<ActionResult> Register([FromBody] UserRequest data)
        //{

        //    if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password) || string.IsNullOrEmpty(data.Email) || data.IdUserRole is null)
        //        throw new Exception();

        //    var repUser = _unitOfWork.GetRepository<User>();

        //    var users = repUser.GetAll();

        //    users = users.Where(u => u.Login == data.Login || u.Email == data.Email);

        //    var listUser = await users.ToListAsync();

        //    if (listUser.Count > 0) throw new Exception();

        //    DateTime now = DateTime.Now;

        //    repUser.Create(new User()
        //    {
        //        IdUserRole = data.IdUserRole,
        //        Login = data.Login,
        //        Email = data.Email,
        //        Hash = Security.GetHash($"{now}{data.Password}{now}"),
        //        CreatedAt = now
        //    });

        //    await _unitOfWork.SaveChangesAsync();

        //    return new JsonResult(new
        //    {
        //        success = "Пользователь зарегестрирован!"
        //    });
        //}

        //[HttpPost("Token")]
        //public async Task<ActionResult> Token([FromBody] UserRequest data)
        //{
        //    var identity = await GetIdentity(data.Login, data.Password);

        //    if (identity == null)
        //    {
        //        return new JsonResult(new { errorText = "Логин или пароль не подходят." });
        //    }

        //    var now = DateTime.UtcNow;
        //    // создаем JWT-токен
        //    var jwt = new JwtSecurityToken(
        //            issuer: _conf.AuthOptions.Issuer,
        //            audience: _conf.AuthOptions.Audience,
        //            notBefore: now,
        //            claims: identity.Claims,
        //            expires: now.Add(TimeSpan.FromHours(_conf.AuthOptions.Lifetime)),
        //            signingCredentials: new SigningCredentials(_conf.AuthOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256));

        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    Response.Cookies.Append("jwt", encodedJwt, new CookieOptions
        //    {
        //        SameSite = SameSiteMode.None,
        //        Secure = true
        //    });

        //    var repUser = _unitOfWork.GetRepository<User>();
        //    var repRole = _unitOfWork.GetRepository<UserRole>();

        //    var users = repUser.GetAll();
        //    var roles = repRole.GetAll();

        //    var user = await users.Where(u => u.Login == data.Login).Join(roles, u => u.IdUserRole, r => r.Id, (u, c) => new User
        //    {
        //        Id = u.Id,
        //        Login = u.Login,
        //        Email = u.Email,
        //        Hash = u.Hash,
        //        CreatedAt = u.CreatedAt,
        //        UpdatedAt = u.UpdatedAt,
        //        UserRole =
        //            new UserRole
        //            {
        //                Id = c.Id,
        //                Name = c.Name
        //            },

        //    }).FirstOrDefaultAsync();

        //    var person = new
        //    {
        //        id = user.Id,
        //        login = identity.Name,
        //        email = user.Email,
        //        role = user?.UserRole?.Name
        //    };

        //    return new JsonResult(person);
        //}

        //[HttpPost("Logout")]
        //public JsonResult Logout()
        //{
        //    Response.Cookies.Append("jwt", "", new CookieOptions()
        //    {
        //        Expires = DateTime.Now.AddDays(-1),
        //        SameSite = SameSiteMode.None,
        //        Secure = true
        //    });

        //    return new JsonResult(new { message = "Вы успешно вышли." });
        //}

        //private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        //{
        //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) throw new Exception();

        //    var repUser = _unitOfWork.GetRepository<User>();
        //    var repRole = _unitOfWork.GetRepository<UserRole>();

        //    var userSup = await repUser.GetAll().Where(u => u.Login == login).FirstOrDefaultAsync();

        //    var pas = Security.GetHash($"{userSup.CreatedAt}{password}{userSup.CreatedAt}");

        //    var users = repUser.GetAll();
        //    var roles = repRole.GetAll();

        //    var verifieduser = await users.Where(u => u.Login == login && pas == u.Hash).Join(roles, u => u.IdUserRole, r => r.Id, (u, c) => new User
        //    {
        //        Id = u.Id,
        //        Login = u.Login,
        //        Email = u.Email,
        //        Hash = u.Hash,
        //        CreatedAt = u.CreatedAt,
        //        UpdatedAt = u.UpdatedAt,
        //        UserRole =
        //            new UserRole
        //            {
        //                Id = c.Id,
        //                Name = c.Name
        //            },

        //    }).FirstOrDefaultAsync();

        //    if (verifieduser != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, verifieduser.Login),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, verifieduser?.UserRole?.Name ?? "admin")
        //        };
        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }

        //    throw new Exception();
        //}
    }
}
