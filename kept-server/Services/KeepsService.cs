using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using kept_server.Models;
using kept_server.Repositories;

namespace kept_server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }
  }
}