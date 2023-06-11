using Identities.Application.Contracts;
using Identities.Application.Registrations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IdentitiesModule _identitiesModule;

        public RegistrationsController(IdentitiesModule identitiesModule)
        { 
            _identitiesModule = identitiesModule;
        }

        [HttpPost]
        public async Task Register()
        {
            await _identitiesModule.Execute(new RegisterNewUserCommand("asdasdasd", "asdasds212323"));
        }
    }
}
