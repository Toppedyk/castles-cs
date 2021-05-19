using System;
using System.Collections.Generic;
using castles.Models;
using castles.Services;
using Microsoft.AspNetCore.Mvc;

namespace castles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly CastlesService _service;

    public CastlesController(CastlesService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Castle>> GetAll()
    {
        try
        {
            IEnumerable<Castle> myCastles = _service.GetAll();
            return Ok(myCastles);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Castle> GetById(int id)
    {
        try
        {
            Castle castle = _service.GetById(id);
            return Ok(castle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    } 

    [HttpPost]
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
        try
        {
            Castle castle = _service.Create(newCastle);
            return Ok(castle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Castle> Edit(int id, [FromBody] Castle update)
    {
        try
        {
            update.Id = id;
            Castle updated = _service.Edit(update);
            return Ok(updated);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
     [HttpDelete("{id}")]
     public ActionResult<string> DeleteCastle(int id)
     {
         try
         {
             _service.DeleteCastle(id);
             return Ok("Successfully Deleted");
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
     }


  }
}