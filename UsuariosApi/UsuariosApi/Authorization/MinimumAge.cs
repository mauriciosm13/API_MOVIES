using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization
{
    public class MinimumAge : IAuthorizationRequirement
    {
        public MinimumAge(int idade)
        {
            Idade = idade;
        }
        public int Idade { get; set; }
    }
}