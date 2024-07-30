using MyFirstApi.Models;

namespace MyFirstApi.Services;

public interface IPostService
{
    Task CreatePost(Post item);

    Task<Post?> UpdatePost(int id, Post item);

    Task<Post?> GetPost(int id);

    Task<List<Post>> GetAllPosts();
    
    Task DeletePost(int id);
}