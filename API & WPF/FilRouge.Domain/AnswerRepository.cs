using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Repositories
{
    public class AnswerRepository : BaseRepository, IRepository<Answer>
    {
        public AnswerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Answer Get(int id)
        {
            return _dataContext.Answers
                .Include(a => a.User)
                .Include(a => a.Comments)
                .Include(a => a.Post)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Answer> GetAll()
        {
            return _dataContext.Answers
                .Include(a => a.User)
                .Include(a => a.Comments)
                .Include(a => a.Post)
                .ToList();
        }

        public Answer Search(Expression<Func<Answer, bool>> searchMethod)
        {
            return _dataContext.Answers
                .Include(a => a.User)
                .Include(a => a.Comments)
                .Include(a => a.Post)
                .FirstOrDefault(searchMethod);
        }

        public List<Answer> SearchAll(Expression<Func<Answer, bool>> searchMethod)
        {
            return _dataContext.Answers
                .Include(a => a.User)
                .Include(a => a.Comments)
                .Include(a => a.Post)
                .Where(searchMethod).ToList();
        }

        public bool Add(Answer entity)
        {
            _dataContext.Answers.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _dataContext.Answers.Remove(Get(id));
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(int id, Answer entity)
        {
            Answer a = Get(id);

            if (a != null)
            {
                a.Content = entity.Content;
                a.Score = entity.Score;
                a.EditedAt = DateTime.Now;
            }

            return _dataContext.SaveChanges() > 0;
        }
    }
}