using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CentralErros.Api.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace CentralErros.Services
{
    public class UserProfileService : IProfileService
    {
        private CentralErroContexto _context;

        // utilizar o mesmo banco atual
        public UserProfileService(CentralErroContexto context)
        {
            _context = context;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // cast token to objeto
            var request = context.ValidatedRequest as ValidatedTokenRequest;

            // verificar se o token � nulo
            if (request != null)
            {
                // buscar o usu�rio na base e add as respectivas claims
                var user = _context.Usuarios.FirstOrDefault(x => x.Nome == request.UserName);
                if (user != null)
                    context.AddRequestedClaims(GetUserClaims(user));
            }

            return Task.CompletedTask;
        }

        //set contexto ativo
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        //add claims
        public static Claim[] GetUserClaims(Usuario user)
        {
            return new []
            {
                new Claim(ClaimTypes.Name, user.Nome ?? ""),
                new Claim(ClaimTypes.Email, user.Email.TrimEnd() ?? ""),
                new Claim(ClaimTypes.Role, "user")
            };
        }

    }
}