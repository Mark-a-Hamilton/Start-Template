

namespace MinAPI.Library.EndPoints
{
    public static class DataEndpoint
    {
        public static void AddDataEndpoints(this IEndpointRouteBuilder app)
        {
            #region Log Table Endpoints
            string url = "/api/URL";    // Common URL Path for all Endpoints in region

            static async Task<List<Log>> GetData(LogContext context) => await context.Log.ToListAsync();

            app.MapGet(url, async (LogContext context) =>
            {
                return Results.Ok(await GetData(context));
            }).WithName("GetAllLogEntries").WithOpenApi();

            app.MapGet(url + "/{Id}", async (LogContext context, int Id) =>
            {
                var item = await context.Log.FindAsync(Id);
                return (item == null) ? Results.NotFound($"Log Entry with Id: {Id} Not Found") :
                                        Results.Ok(item);
            }).WithName("GetLogById").WithOpenApi();

            app.MapPost(url, async (LogContext context, Log item) =>
            {
                await context.Log.AddAsync(item);
                await context.SaveChangesAsync();
                return Results.Created();
            }).WithName("PostLogToDatabase").WithOpenApi().AddEndpointFilter<Validation<Log>>();

            app.MapPut(url + "/{Id}", async (LogContext context, Log item, int Id) =>
            {
                var logItem = await context.Log.FindAsync(Id);
                if (logItem == null) return Results.NotFound($"Unable To Update, Log Entry with Id: {Id} was Not Found");
                logItem.Level = item.Level;
                logItem.Message = item.Message;
                logItem.Exception = item.Exception;
                logItem.Properties = item.Properties;
                context.Log.Update(logItem);
                await context.SaveChangesAsync();
                return Results.Ok();
            }).WithName("PutLogById").WithOpenApi().AddEndpointFilter<Validation<Log>>();

            app.MapPatch(url + "/{Id}", async (LogContext context, Log item, int Id) =>
            {
                var logItem = await context.Log.FindAsync(Id);
                if (logItem == null) return Results.NotFound($"Unable To Pqrtially Update Log Entry with Id: {Id} was Not Found");
                if (item.Level != null) logItem.Level = item.Level;
                if (item.Message != null) logItem.Message = item.Message;
                if (item.Exception != null) logItem.Exception = item.Exception;
                if (item.Properties != null) logItem.Properties = item.Properties;
                context.Log.Update(logItem);
                await context.SaveChangesAsync();
                return Results.Accepted();
            }).WithName("PatchLogById").WithOpenApi().AddEndpointFilter<Validation<Log>>();

            app.MapDelete(url + "/{Id}", async (LogContext context, int Id) =>
            {
                var item = await context.Log.FindAsync(Id);
                if (item == null) return Results.NotFound($"Unable To Delete Log Entry with Id: {Id} was Not Found");
                context.Remove(item);
                await context.SaveChangesAsync();
                return (await context.Log.FindAsync(Id) != null) ?
                    Results.Problem("Item Could not ve deleted") :
                    Results.Ok();
            }).WithName("DeleteLogById").WithOpenApi();
            #endregion
        }
    }
}