using System;
using System.Collections.Generic;
using castles.Models;
using castles.Repositories;

namespace castles.Services
{
  public class CastlesService
  {

    private readonly CastlesRepository _repo;

    public CastlesService(CastlesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Castle> GetAll()
    {
      return _repo.GetAll();
    }

    internal Castle GetById(int id)
    {
      Castle castle = _repo.GetById(id);
      if(castle == null)
      {
        throw new Exception("Invalid ID");
      }
      return castle;
    }

    internal Castle Create(Castle newCastle)
    {
      Castle castle = _repo.Create(newCastle);
      return castle;
    }

    internal Castle Edit(Castle update)
    {
      Castle original = GetById(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Location = update.Location.Length > 0 ? update.Location : original.Location;
      original.YearBuilt = update.YearBuilt > 0 ? update.YearBuilt : original.YearBuilt;
      original.TimesInvaded = update.TimesInvaded > 0 ? update.TimesInvaded : original.TimesInvaded;
      original.ImgUrl = update.ImgUrl.Length > 0 ? update.ImgUrl : original.ImgUrl;

      if(_repo.Edit(original))
      {
        return original;
      }
      throw new Exception("Something went wrong!");
    }

    internal void DeleteCastle(int id)
    {
      GetById(id);
      _repo.DeleteCastle(id);
    }
  }
}