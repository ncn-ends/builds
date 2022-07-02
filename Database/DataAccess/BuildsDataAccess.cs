using Database.Models;

namespace Database.DataAccess;

public interface IBuildsDataAccess
{
    Task<IEnumerable<BuildBO>> GetBuilds();
    Task<BuildBO?> GetOneBuildById(int id);

    Task CreateOneBuild(string title);
    Task UpdateOneBuildById(int id, string title);
    Task ArchiveOneBuildById(int id);
}

public class BuildsDataAccessAccess : IBuildsDataAccess
{
    private readonly ISqlDataAccess _db;

    public BuildsDataAccessAccess(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<BuildBO>> GetBuilds() =>
        _db.LoadData<BuildBO, dynamic>("Builds_GetAll", new { });


    public async Task<BuildBO?> GetOneBuildById(int id)
    {
        var results = await _db.LoadData<BuildBO, dynamic>(
            "Builds_GetOneById",
            new {_build_id_to_find = id}
        );

        return results.FirstOrDefault();
    }
    
    
    public async Task CreateOneBuild(string title)
    {
        await _db.SaveDataSP<dynamic>(
            "CALL Builds_InsertOne(@title)",
            new {title = title}
        );
    }
    
    
    public async Task UpdateOneBuildById(int id, string title)
    {
        await _db.SaveDataSP<dynamic>(
            "CALL Builds_UpdateOneById(@id, @title)",
            new {id = id, title = title}
        );
    }
    
    
    public async Task ArchiveOneBuildById(int id)
    {
        await _db.SaveDataSP<dynamic>(
            "CALL Builds_ArchiveOneById(@id)",
            new {id = id}
        );
    }
}