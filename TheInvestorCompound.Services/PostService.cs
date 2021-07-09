using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestorCompound.Data;
using TheInvestorCompound.Models;

namespace TheInvestorCompound.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        // Create
        public bool CreatePost(PostCreate model)
        {
            Post entity = new Post
            {
                PostedBy = _userId,
                PostName = model.PostName,
                PostCoverImage = model.PostCoverImage,
                PostContent = model.PostContent,
                CreatedUtc = DateTimeOffset.Now
            };

            ctx.Posts.Add(entity);
            return ctx.SaveChanges() == 1;
        }

        // Get Notes

        public IEnumerable<PostListItem> GetPosts()
        {
            var query = ctx.Posts.Select(
                e => new PostListItem
                {
                    PostId = e.PostId,
                    PostedBy = e.PostedBy,
                    PostName = e.PostName,
                    CreatedUtc = e.CreatedUtc
                });
            return query.ToArray();
        }
        // Get (ID)
    }
}
