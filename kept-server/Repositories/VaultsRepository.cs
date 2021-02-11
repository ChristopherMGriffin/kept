using System;
using System.Collections.Generic;
using kept_server.Models;
using Dapper;
using System.Data;

namespace kept_server.Services
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT vault.*, profile.* FROM vaults vault INNER JOIN profiles profile ON vault.creatorId = profile.id";

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> Get()
    {
      string sql = populateCreator + " WHERE isPublished = 1";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, splitOn: "id");
    }

    internal Vault GetOne(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    public int Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (name, creatorId, isPublished, description, img)
      VALUES
      (@Name, @CreatorId, @IsPublished, @Description, @Img)
      ;SELECT LAST_INSERT_ID()";
      
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal void Edit(Vault vault)
    {
      string sql = @"
     UPDATE vaults
     SET
     name = @Name,
     isPublished = @IsPublished
     Where id = @Id;";
      _db.Execute(sql, vault);
    }

    internal IEnumerable<Vault> GetVaultsByProfile(string profileId)
    {
      string sql = @"SELECT vault.*, p.* FROM vaults vault JOIN profiles p ON vault.creatorId = p.id WHERE vault.creatorId = @profileId";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { profileId }, splitOn: "id");
    }

  }
}