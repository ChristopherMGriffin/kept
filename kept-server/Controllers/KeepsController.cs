using Microsoft.AspNetCore.Mvc;
using kept_server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using kept_server.Models;
using CodeWorks.Auth0Provider;
using System.Collections.Generic;
using System;
using System.Linq;
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
    [Authorize]
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

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
          return Ok(_ks.Get());
      }
      catch (System.Exception e)
      {
          
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetOne(int id)
    {
      try
      {
          return Ok(_ks.GetOne(id));
      }
      catch (System.Exception e)
      {
          
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ks.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
          
        return BadRequest(e.Message);
      }
    }
  }
}