namespace MyFirstApi.Graphql.Graphql.Mutations;

public record AddTeacherInput(
    string FirstName,
    string LastName,
    string Email,
    string? Phone,
    string? Bio);