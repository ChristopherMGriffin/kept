using System;
using System.Collections.Generic;
using kept_server.Models;
using kept_server.Repositories;

namespace kept_server.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
  
    public Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile foundProfile = _repo.GetOneProfile(userInfo.Id);
      if (foundProfile == null)
      {
        return _repo.Create(userInfo);
      }
      return foundProfile;
    }

    public Profile GetOneProfile(string id)
    {
      return _repo.GetOneProfile(id);
    }
  }
}