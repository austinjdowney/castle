using System;
using System.Collections.Generic;
using System.Data;
using castle.Models;
using Dapper;

namespace castle.Repositories
{
  public class CastlesRepository
  {

    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Castle> GetAll()
    {
      string sql = "SELECT * FROM castles";
      return _db.Query<Castle>(sql);
    }

    internal Castle GetById(int id)
    {
      // Dapper uses '@' to indicate a variable that can be safeley injectected in the Query arguments

      string sql = "SELECT * FROM castles WHERE id = @id";
      //   Query first or default returns a single item or null
      return _db.QueryFirstOrDefault<Castle>(sql, new { id });
    }

    internal bool Delete(int id)
    {
      // Dapper uses '@' to indicate a variable that can be safeley injectected in the Query arguments
      string sql = "DELETE FROM castles WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal Castle Create(Castle newCastle)
    {
      string sql = @"
INSERT INTO castles
(name, yearbuilt, yearlastinvaded, location, imgurl)
VALUES
(@name, @yearbuilt, @yearlastinvaded, @location, @imgurl);
SELECT LAST_INSERT_ID()";

      newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
      return newCastle;
    }

    internal bool Update(Castle original)
    {
      string sql = @"
        UPDATE castles
        SET
            name= @Name,
            yearbuilt = @YearBuilt,
            yearlastinvaded = @YearLastInvaded,
            location = @Location,
            imgurl = @ImgUrl
        WHERE id= @Id";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }
  }
}