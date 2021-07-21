using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestorCompound.Data;
using TheInvestorCompound.Models;

namespace TheInvestorCompound.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        // Create
        public bool CreateComment(CommentCreate model)
        {
            Comment entity = new Comment
            {
                CommentedBy = _userId,
                CommentContent = model.CommentContent,
                CreatedUtc = DateTimeOffset.Now
            };

            ctx.Comments.Add(entity);
            return ctx.SaveChanges() == 1;
        }

        // Get Notes

        public IEnumerable<CommentList> GetComments()
        {
            var query = ctx.Comments.Select(
                e => new CommentList
                {
                    CommentId = e.CommentId,
                    CommentedBy = e.CommentedBy,
                    CommentContent = e.CommentContent,
                    CreatedUtc = e.CreatedUtc
                });
            return query.ToArray();
        }
        // Update
        public bool UpdateComment(CommentEdit model)
        {
            var entity = ctx.Comments.Single(
                e => e.CommentId == model.CommentId && e.CommentedBy == _userId);

            entity.CommentContent = model.CommentContent;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
        public bool DeleteComment(int commentId)
        {
            var entity = ctx.Comments.Single(
                e => e.CommentId == commentId && e.CommentedBy == _userId);

            ctx.Comments.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
