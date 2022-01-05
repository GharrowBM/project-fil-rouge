using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Repositories
{
    public class CommentRepository : BaseRepository, IRepository<Comment>
    {
        public CommentRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Comment Get(int id)
        {
            return _dataContext.Comments
                .Include(c => c.Answer)
                .Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetAll()
        {
            return _dataContext.Comments
                .Include(c => c.Answer)
                .Include(c => c.User)
                .ToList();
        }

        public Comment Search(Expression<Func<Comment, bool>> searchMethod)
        {
            return _dataContext.Comments
                .Include(c => c.Answer)
                .Include(c => c.User)
                .FirstOrDefault(searchMethod);
        }

        public List<Comment> SearchAll(Expression<Func<Comment, bool>> searchMethod)
        {
            return _dataContext.Comments
                .Include(c => c.Answer)
                .Include(c => c.User)
                .Where(searchMethod).ToList();
        }

        public bool Add(Comment entity)
        {
            _dataContext.Comments.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _dataContext.Comments.Remove(Get(id));
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(int id, Comment entity)
        {
            Comment c = Get(id);

            if (c != null)
            {
                c.Answer = entity.Answer;
                c.Content = entity.Content;
                c.Score = entity.Score;
                c.User = entity.User;
                c.AnswerId = entity.AnswerId;
                c.EditedAt = entity.EditedAt;
                c.UserId = entity.UserId;
            }

            return _dataContext.SaveChanges() > 0;
        }
    }
}