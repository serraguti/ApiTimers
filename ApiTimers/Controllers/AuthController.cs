using ApiTimers.Helpers;
using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiTimers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryTimers repo;
        HelperToken helper;

        public AuthController(RepositoryTimers repo
            , IConfiguration configuration)
        {
            this.helper = new HelperToken(configuration);
            this.repo = repo;
        }

        //NECESITAMOS UN PUNTO DE ENTRADA (ENDPOINT) PARA QUE EL 
        //USUARIO NOS ENVIE LOS DATOS DE SU VALIDACION
        //LOS ENDPOINT AUTH SON POST
        //LO QUE RECIBIREMOS SERA UserName y Password
        //QUE NOSOTROS LO HEMOS INCLUIDO CON LoginModel
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Usuario user =
                this.repo.ExisteUsuario(model.UserName
                , model.Password);
            if (user != null)
            {
                //NECESITAMOS CREARNOS UN TOKEN
                //EL TOKEN LLEVARA INFORMACION DE TIPO ISSUER
                //, TIEMPO DE DURACION
                //, CREDENCIALES DEL USUARIO
                //, PODEMOS ALMACENAR INFO EXTRA DENTRO DEL TOKEN.
                //VAMOS A ALMACENAR A NUESTRO EMPLEADO
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(user))
                };

                JwtSecurityToken token = new JwtSecurityToken
                    (
                     issuer: helper.Issuer
                     , audience: helper.Audience
                     , claims: claims
                     , expires: DateTime.UtcNow.AddMinutes(500)
                     , notBefore: DateTime.UtcNow
                     , signingCredentials:
new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256)
                    );
                //DEVOLVEMOS UNA RESPUESTA AFIRMATIVA
                //CON SU TOKEN
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
