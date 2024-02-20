using Microsoft.AspNetCore.Diagnostics;

namespace App.Toolbox;
public class GblExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}