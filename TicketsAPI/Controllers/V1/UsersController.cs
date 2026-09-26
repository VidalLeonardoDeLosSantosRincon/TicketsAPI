using Asp.Versioning;
using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
[ApiController]
public class UsersController : ControllerBase, IUsersController
{

}
