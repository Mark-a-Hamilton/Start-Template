using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class LogContext : DbContext
{
    public LogContext(DbContextOptions options) : base(options)
    {
            
    }
}