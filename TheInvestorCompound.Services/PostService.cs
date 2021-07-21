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
        public PostDetail GetPostById(int id)
        {
            var entity = ctx.Posts.Single(
                e => e.PostId == id);
            return new PostDetail
            {
                PostId = entity.PostId,
                PostName = entity.PostName,
                PostCoverImage = entity.PostCoverImage,
                PostContent = entity.PostContent,
                CreatedUtc = entity.CreatedUtc,
                ModifiedUtc = entity.ModifiedUtc
            };
        }
        public bool UpdatePost(PostEdit model)
        {
            var entity = ctx.Posts.Single(
                e => e.PostId == model.PostId && e.PostedBy == _userId);

            entity.PostName = model.PostName;
            entity.PostCoverImage = model.PostCoverImage;
            entity.PostContent = model.PostContent;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
        public bool DeletePost(int postId)
        {
            var entity = ctx.Posts.Single(
                e => e.PostId == postId && e.PostedBy == _userId);

            ctx.Posts.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
