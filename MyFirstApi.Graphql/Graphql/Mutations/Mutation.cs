﻿using MyFirstApi.Graphql.Data;
using MyFirstApi.Graphql.Models;

namespace MyFirstApi.Graphql.Graphql.Mutations;

public class Mutation
{
    public async Task<AddTeacherPayload> AddTeacherAsync(AddTeacherInput input, [Service] AppDbContext context)
    {
        var teacher = new Teacher
        {
            Id = Guid.NewGuid(),
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            Phone = input.Phone,
            Bio = input.Bio
        };

        context.Teachers.Add(teacher);

        await context.SaveChangesAsync();

        return new AddTeacherPayload(teacher);
    }
}