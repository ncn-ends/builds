using Database.DataAccess;

namespace Api.Endpoints;

public static class BuildsEndpoints
{
    public static void ConfigureBuildsEndpoints(this WebApplication app)
    {
        app.MapGet("/builds", GetBuilds);
        app.MapGet("/builds/{id}", GetBuildById);
        app.MapPost("/builds/create", CreateOneBuild);
        app.MapPut("/builds/update", UpdateOneBuildById);
        app.MapDelete("/builds/archive", ArchiveOneById);
    }

    private static async Task<IResult> GetBuilds(IBuildsDataAccess dataAccess)
    {
        try
        {
            return Results.Ok(await dataAccess.GetBuilds());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return Results.Problem(e.Message);
        }
    }
    
    private static async Task<IResult> GetBuildById(int id, IBuildsDataAccess dataAccess)
    {
        try
        {
            var results = await dataAccess.GetOneBuildById(id);
            if (results is null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return Results.Problem(e.Message);
        }
    }
    
    
    private static async Task<IResult> CreateOneBuild(string title, IBuildsDataAccess dataAccess)
    {
        try
        {
            await dataAccess.CreateOneBuild(title);
            return Results.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> UpdateOneBuildById(int id, string title, IBuildsDataAccess dataAccess)
    {
        try
        {
            await dataAccess.UpdateOneBuildById(id, title);
            return Results.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> ArchiveOneById(int id, IBuildsDataAccess dataAccess)
    {
        try
        {
            await dataAccess.ArchiveOneBuildById(id);
            return Results.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return Results.Problem(e.Message);
        }
    }
}