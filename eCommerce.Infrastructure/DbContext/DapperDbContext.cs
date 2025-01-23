﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;
public class DapperDbContext
{
    private readonly IDbConnection _connection;

    private readonly IConfiguration _configuration;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;

        string connectionString = connectionStringTemplate
       .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
       .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"))
       .Replace("$POSTGRES_DATABASE", Environment.GetEnvironmentVariable("POSTGRES_DATABASE"))
       .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT"))
       .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"));
        Console.WriteLine($"[DEBUG] Actual MongoDB connection string: {connectionString}");
        //create new NpgsqlConnection
        _connection = new NpgsqlConnection(connectionString);

    }

    public IDbConnection DbConnection => _connection;
}
