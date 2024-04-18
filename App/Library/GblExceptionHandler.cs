namespace App.Library;

public class GblExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext c, 
        Exception e, 
        CancellationToken t)
    {
        Log.Error($"Exception: {e.Message} - HTTP Context: {c}", e);
        return new ValueTask<bool>(false);
    }
}