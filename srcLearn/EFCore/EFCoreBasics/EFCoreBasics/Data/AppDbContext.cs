﻿using EFCoreBasics.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBasics.Data;

internal class AppDbContext : DbContext
{
    private string ConnectionString { get; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }

    public AppDbContext()
    {
        // 数据库连接
        ConnectionString = "Data Source=DESKTOP-C6B113V;Initial Catalog=EmployeeMngt_EFCorePractice;IntegratedSecurity=True";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}
