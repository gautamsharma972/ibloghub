using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBlogHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly IPostsService _postService;
        public FeedsController(IPostsService postService)
        {
            _postService = postService;
        }

        // GET: api/Feeds
        [HttpGet]
        public async Task<IList<PostsViewModel>> GetAsync()
        {
            var obj = await _postService.Get();
            
            return obj.ToList();
        }

        // GET: api/Feeds/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<PostsViewModel> Get(string slug)
        {
            return await _postService.Get(slug);
        }

        // POST: api/Feeds
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Feeds/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
