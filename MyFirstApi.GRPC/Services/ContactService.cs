using Grpc.Core;
using Microsoft.AspNetCore.Mvc.Controllers;
using MyApp.Namespace;

namespace MyFirstApi.GRPC.Services;

public class ContactService(ILogger<ContactService> logger) : Contact.ContactBase
{
    public override Task<CreateContactResponse> CreateContact(CreateContactRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CreateContactResponse
        {
            ContactId = Guid.NewGuid().ToString()
        });
    }
}