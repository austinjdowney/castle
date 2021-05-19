using System;
using System.Collections.Generic;
using castle.Models;
using castle.Repositories;

namespace castle.Services
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
      if (castle == null)
      {
        throw new Exception("Invalid Id");
      }
      return castle;
    }

    internal Castle Update(Castle update)
    {
      Castle original = GetById(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.YearBuilt = update.YearBuilt > 0 ? update.YearBuilt : original.YearBuilt;
      original.YearLastInvaded = update.YearLastInvaded > 0 ? update.YearLastInvaded : original.YearLastInvaded;
      original.Location = update.Location.Length > 0 ? update.Location : original.Location;
      original.ImgUrl = update.ImgUrl.Length > 0 ? update.ImgUrl : original.ImgUrl;

      if (_repo.Update(original))
      {
        throw new Exception("Invalid Response");
      }
      return original;
    }

    internal Castle Create(Castle newCastle)
    {
      Castle castle = _repo.Create(newCastle);
      return castle;
    }

    internal void DeleteCastle(int id)
    {
      GetById(id);
      _repo.Delete(id);
    }
  }
}