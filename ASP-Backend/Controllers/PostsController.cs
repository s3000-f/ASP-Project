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
        public async Task<ActionResult<IEnumerable<Post2>>> GetPosts()
        {
            var ps = _context.Posts.ToList();
            var ps2 = new List<Post2>();
            foreach (var post in ps)
            {
                ps2.Add(new Post2(post, _context));
            }
            return ps2;
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post2>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return new Post2(post, _context);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.CreatedAt = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
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
        public async Task<ActionResult<Post>> DeletePost(int id)
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
        public async Task<ActionResult<IEnumerable<Comment2>>> GetPostComments(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var cs2 = new List<Comment2>();

            if (post.Comments != null)
            {
                var cs = post.Comments.ToList();
                foreach (var c in cs)
                {
                    cs2.Add(new Comment2(c, _context));
                }
            }
            
            return cs2;
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<Comment2>> SetPostComment(int id, Comment c)
        {
            c.CreatedAt = DateTime.Now;
            c.PostId = id;
            _context.Comments.Add(c);
            await _context.SaveChangesAsync();

            return new Comment2(c, _context);
        }

        //Likes -------------------------------------------
        [HttpPost("{id}/like")]
        public async Task<ActionResult<Post2>> AddLike(int id,Likes like)
        {
            like.CreatedAt = DateTime.Now;
            like.PostId = id;
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return new Post2(post, _context);
        }

        [HttpDelete("{id}/like/{id2}")]
        public async Task<ActionResult<Post2>> RemoveLike(int id, int id2)
        {
            var l = await _context.Likes.FindAsync(id2);
            if (l == null)
            {
                return NotFound();
            }
            _context.Likes.Remove(l);
            await _context.SaveChangesAsync();
            var post = await _context.Posts.FindAsync(id);
            return new Post2(post, _context);
        }

    }
}

