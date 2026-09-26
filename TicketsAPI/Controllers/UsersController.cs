using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Domain.Constants;
using TicketsAPI.Interfaces.Controllers;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase, IUsersController
{

}
