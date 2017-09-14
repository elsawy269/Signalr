using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChatAPP.Modals;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using ChatAPP.Hubs;
using Microsoft.AspNetCore.Cors;

namespace ChatAPP.Controllers
{
     [Route("api/Posts")]
    [EnableCors("AllowSpecificOrigin")]
    public class PostsController : Controller
    {
        private IPostRepository _postRepository { get; set; }
        private IConnectionManager _connectionManager { get; set; }

        public PostsController(IPostRepository postRepository, IConnectionManager connectionManager)
        {
            _postRepository = postRepository;
            _connectionManager = connectionManager;
        }


        [HttpGet("GetPosts")]
        public List<Post> GetPosts()
        {
            return _postRepository.GetAll();
        }

        [HttpGet("GetPost/{id}")]
        public Post GetPost(int id)
        {
            return _postRepository.GetPost(id);
        }

        [HttpPost("AddPost")]
        public void AddPost(Post post)
        {
            _postRepository.AddPost(post);
            _connectionManager.GetHubContext<PostsHub>().Clients.All.publishPost(post);

        }
    }
}