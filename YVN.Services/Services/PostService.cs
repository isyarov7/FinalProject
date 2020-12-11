using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YVN.Database;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Services.MappersDTO;
using static YVN.Services.Mesages.Constant_ExceptionMessages;
using YVN.Models.Enums;


namespace YVN.Services.Services
{
    public class PostService : IPostService
    {
        private readonly YvnDbContext _context;

        public PostService(YvnDbContext context)
        {
            _context = context;
        }

        public async Task<PostDTO> Create(PostDTO postDTO)
        {
            if (postDTO == null)
            {
                throw new Exception(PostNull);
            }

            var post = new Post
            {
                Content = postDTO.Content,
                UserId = postDTO.UserId,
                CreatedOn = DateTime.UtcNow,
                Visability = postDTO.Visability
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post.GetDTO();
        }

        public async Task<bool> Delete(int id)
        {
            var post = await this._context.Posts
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (post == null)
            {
                return false;
            }

            post.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PostDTO> Edit(PostDTO postDTO)
        {
            var post = await this._context.Posts
                .FirstOrDefaultAsync(x => x.Id == postDTO.Id && x.IsDeleted == false);

            _context.Posts.Remove(post);

            var newPost = postDTO.GetPost();

            this._context.Posts.Add(newPost);

            await _context.SaveChangesAsync();

            return post.GetDTO();
        }

        public async Task<PostDTO> GetAllLikes(int id)
        {
            var post = await this._context.Posts
                .Include(r => r.Likes)
                .FirstOrDefaultAsync(r => r.Id == id);

            return post.GetDTO();
        }

        public async Task<bool> PostExsist(int id)
        {
            return await _context.Photos.AnyAsync(p => p.Id == id && !p.IsDeleted);
        }
        public async Task<ICollection<PostDTO>> GetAllPostByUser(int userId)
        {

            var userPosts = await _context.Posts.Where(p => p.UserId == userId && !p.IsDeleted).ToListAsync();

            if (userPosts == null)
            {
                throw new Exception(POST_NULL);
            }

            return userPosts.GetDTO();
        }

        public async Task<PostDTO> GetPost(int id)
        {
            var post = await this._context.Posts.Where(p => !p.IsDeleted)
            .FirstOrDefaultAsync(post => post.Id == id);

            if (post == null)
            {
                throw new Exception(POST_NULL);
            }

            return post.GetDTO();
        }

        // TODO  user cannot like the same post!!!
        public async Task<bool> Like(int id)
        {
            if (await this.PostExsist(id))
            {
                var post = _context.Posts.Find(id);
                post.Likes++;
                _context.SaveChanges();
            }
            throw new Exception(POST_NULL);
        }

        public async Task<ICollection<PostDTO>> GetAllPublicPost()
        {
            var publicPosts = await _context.Posts
                .Include(p => p.User)
                .Where(p => !p.IsDeleted && p.Visability == "Public")
                .OrderBy(p => p.CreatedOn)
                .ToListAsync();

            if (publicPosts == null)
            {
                throw new Exception(POST_NULL);
            }

            return publicPosts.GetDTO();
        }
    }
}
