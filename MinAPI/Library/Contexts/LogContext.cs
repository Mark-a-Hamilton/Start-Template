namespace MinAPI.Library.Contexts;

//  Add a LogContext class for each database accessed
public class LogContext : DbContext
{
    public LogContext(DbContextOptions<LogContext> options) : base(options)
    {
    }

    /*  
     *  Add a DbSet line for each Model DbSet<{MODELNAME}>
     *  the Line should be the tablename which is the same as the MODELNAME
     */
    public DbSet<Log> Log { get; set; }
}