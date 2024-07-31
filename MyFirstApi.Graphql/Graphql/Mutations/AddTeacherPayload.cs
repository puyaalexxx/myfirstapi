using MyFirstApi.Graphql.Models;

namespace MyFirstApi.Graphql.Graphql.Mutations;

public class AddTeacherPayload
{
    public Teacher Teacher { get; set; }

    public AddTeacherPayload(Teacher teacher)
    {
        Teacher = teacher;
    }
}