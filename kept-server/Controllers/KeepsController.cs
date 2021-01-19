using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using kept_server.Models;
using kept_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace kept_server.Controllers
{

  [ApiController]
  [Route("api/[Controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpPost]
    // [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
          Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
          newKeep.creatorId = userInfo.Id;
          Keep created = _ks.Create(newKeep);
          created.Creator = userInfo;
          return Ok(created);
      }
      catch (System.Exception e)
      {
          
        return BadRequest(e.Message);
      }
    }
  }
}