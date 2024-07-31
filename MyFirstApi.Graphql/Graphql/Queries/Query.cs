using Microsoft.EntityFrameworkCore;
using MyFirstApi.Graphql.Data;
using MyFirstApi.Graphql.Models;

namespace MyFirstApi.Graphql.Graphql.Queries;

public class Query
{
    public async Task<List<Teacher>> GetTeachers([Service] AppDbContext context)
    {
        return await context.Teachers.ToListAsync();
    }
    
    public async Task<Teacher?> GetTeacher(Guid id, [Service] AppDbContext context)
    {
        return await context.Teachers.FindAsync();
    }
}