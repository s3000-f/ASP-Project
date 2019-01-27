using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Backend.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly DataContext _context;
        public PostsController(DataContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return _context.Posts.ToList();
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(long id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(long id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        //Comments ----------------------------------------
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(long id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return post.Comments.ToList();
        }

        [HttpGet("{id}/comments/{id2}")]
        public async Task<ActionResult<Comment>> GetPostComment(long id,long id2)
        {
            var comment = await _context.Comments.FindAsync(id2);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

    }
}

