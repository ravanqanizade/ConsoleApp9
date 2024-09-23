using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp9.Context;

public class BaseEntityDContext : DbContext
{
    public DbSet<Products> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=FOSSIGREM\\MSSQLSERVER01;Initial Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }
}