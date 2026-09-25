using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Domain.Constants;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{

}
