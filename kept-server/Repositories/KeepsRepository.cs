using kept_server.Models;
using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace kept_server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keepstable
      (name, description, creatorId, img, tags)
      VALUES
      (@Name, @Description, @ CreatorId, @Img, @Tags);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
  }
}