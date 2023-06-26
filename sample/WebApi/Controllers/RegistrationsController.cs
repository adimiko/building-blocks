using Identities.Application.Contracts;
using Identities.Application.Registrations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IdentitiesModule _identitiesModule;

        public RegistrationsController(IdentitiesModule identitiesModule)
        { 
            _identitiesModule = identitiesModule;
        }

        [HttpPost]
        public async Task Register([FromBody] RegisterNewUserCommand command)
        {
            await _identitiesModule.Execute(command);
        }

        [HttpPost]
        public async Task Confirm([FromBody] ConfirmCommand command)
        {
            await _identitiesModule.Execute(command);
        }
    }
}
