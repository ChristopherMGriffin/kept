using System;
using System.Collections.Generic;
using System.Data;
using kept_server.Models;
using Dapper;

namespace kept_server.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    public Profile GetByEmail(string email)
    {
      string sql = "SELECT * FROM profiles WHERE email = @Email";
      return _db.QueryFirstOrDefault<Profile>(sql, new { email });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (name, picture, email, id)
      VALUES
      (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }

    public Profile GetOneProfile(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @Id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    public IEnumerable<Profile> GetAllProfiles()
    {
      string sql = "SELECT * FROM profiles";
      return (IEnumerable<Profile>)_db.Query(sql);
    }
  }
}