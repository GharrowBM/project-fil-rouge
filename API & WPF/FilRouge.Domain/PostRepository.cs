using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Repositories
{
    public class PostRepository : BaseRepository, IRepository<Post>
    {
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Post Get(int id)
        {
            return _dataContext.Posts
                .Include(p => p.Answers)
                .ThenInclude(a=>a.Comments)
                .Include(p => p.User)
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAll()
        {
            return _dataContext.Posts
                .Include(p => p.Answers)
                .ThenInclude(a=>a.Comments)
                .Include(p => p.User)
                .Include(p => p.Tags)
                .ToList();
        }

        public Post Search(Expression<Func<Post, bool>> searchMethod)
        {
            return _dataContext.Posts
                .Include(p => p.Answers)
                .ThenInclude(a=>a.Comments)
                .Include(p => p.User)
                .Include(p => p.Tags)
                .FirstOrDefault(searchMethod);
        }

        public List<Post> SearchAll(Expression<Func<Post, bool>> searchMethod)
        {
            return _dataContext.Posts
                .Include(p => p.Answers)
                .ThenInclude(a=>a.Comments)
                .Include(p => p.User)
                .Include(p => p.Tags)
                .Where(searchMethod).ToList();
        }

        public bool Add(Post entity)
        {
            _dataContext.Posts.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _dataContext.Posts.Remove(Get(id));
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(int id, Post entity)
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}