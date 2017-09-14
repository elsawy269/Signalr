
using ChatAPP.Modals;
using System.Collections.Generic;

public interface IPostRepository
{
    List<Post> GetAll();
    Post GetPost(int id);
    void AddPost(Post post);
}