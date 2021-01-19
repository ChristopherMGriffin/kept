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
    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keepstable
      (name, description, creatorId, img, tags)
      VALUES
      (@Name, @Description, @CreatorId, @Img, @Tags);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT keep.*, profile.* FROM keepstable keep INNER JOIN profiles profile ON keep.creatorId = profile.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    internal Keep GetOne(int id)
    {
      string sql = @"UPDATE keepstable SET views = views +1 WHERE id = @Id;
      SELECT * FROM keepstable WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal Keep GetDelete(int id)
    {
      string sql = "SELECT * FROM keepstable WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal bool Delete(int id)
    {
      string sql = "DELETE FROM keepstable WHERE id = @Id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string pId)
    {
      string sql = @"
      SELECT keep.*, FROM keepstable keep JOIN profiles p ON keep.creatorId = p.id
      WHERE keep.creatorId = @pId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { pId }, splitOn: "id");
    }

  }
}