using System;
using System.Collections.Generic;
using System.Data;
using castles.Models;
using Dapper;

namespace castles.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _Db;

    public CastlesRepository(IDbConnection db)
    {
      _Db = db;
    }

    internal IEnumerable<Castle> GetAll()
    {
      string sql = "SELECT * FROM castles";
      return _Db.Query<Castle>(sql);
    }

    internal Castle GetById(int id)
    {
      string sql = "SELECT * FROM castles WHERE id = @id";
      return _Db.QueryFirstOrDefault<Castle>(sql, new {id});
    }

    internal Castle Create(Castle newCastle)
    {
      string sql = @"
      INSERT INTO castles
      (name, location, yearbuilt, timesinvaded,imgUrl)
      VALUES
      (@Name, @Location, @YearBuilt, @TimesInvaded, @ImgUrl);
      SELECT LAST_INSERT_ID()";

      newCastle.Id = _Db.ExecuteScalar<int>(sql, newCastle);
      return newCastle;
    }

    internal bool Edit(Castle original)
    {
      string sql = @"
      UPDATE castles
      SET
      name = @Name,
      location = @Location,
      yearbuilt = @YearBuilt,
      timesinvaded = @TimesInvaded,
      imgurl = @ImgUrl
      WHERE id=@Id
      ";
      int affectedRows = _Db.Execute(sql, original);
      return affectedRows == 1;
    }

    internal bool DeleteCastle(int id)
    {
      string sql = "DELETE FROM castles WHERE id=@id LIMIT 1";
      int affectedRows = _Db.Execute(sql, new {id});
      return affectedRows == 1;
    }
  }
}