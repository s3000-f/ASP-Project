using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Backend.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Backend.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly DataContext _context;
        public CommentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment2>>> GetComments()
        {
            var cs =  _context.Comments.ToList();
            var cs2 = new List<Comment2>();
            foreach (var c in cs)
            {
                cs2.Add(new Comment2(c, _context));
            }
            return cs2;

        }

        // GET api/comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment2>> GetComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return new Comment2(comment,_context);
        }

        //Comment Likes -----------------------------------
        [HttpPost("{id}/like")]
        public async Task<ActionResult<Comment2>> AddCommentLike(int id, Clike like)
        {
            like.CreatedAt = DateTime.Now;
            like.CommentId = id;
            _context.Clikes.Add(like);
            await _context.SaveChangesAsync();
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return new Comment2(comment, _context);
        }

        [HttpDelete("{id}/like/{id2}")]
        public async Task<ActionResult<Comment2>> RemoveCommentLike(int id, int id2)
        {
            var l = await _context.Clikes.FindAsync(id2);
            if (l == null)
            {
                return NotFound();
            }
            _context.Clikes.Remove(l);
            await _context.SaveChangesAsync();
            var comment = await _context.Comments.FindAsync(id);
            return new Comment2(comment, _context);
        }

    }
}
