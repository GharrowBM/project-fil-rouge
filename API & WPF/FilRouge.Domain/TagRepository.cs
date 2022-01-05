using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Repositories
{
    public class TagRepository : BaseRepository, IRepository<Tag>
    {
        public TagRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Tag Get(int id)
        {
            return _dataContext.Tags
                .Include(t => t.Subscribers)
                .Include(t => t.RelatedPosts)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Tag> GetAll()
        {
            return _dataContext.Tags
                .Include(t => t.Subscribers)
                .Include(t => t.RelatedPosts)
                .ToList();
        }

        public Tag Search(Expression<Func<Tag, bool>> searchMethod)
        {
            return _dataContext.Tags
                .Include(t => t.Subscribers)
                .Include(t => t.RelatedPosts)
                .FirstOrDefault(searchMethod);
        }

        public List<Tag> SearchAll(Expression<Func<Tag, bool>> searchMethod)
        {
            return _dataContext.Tags
                .Include(t => t.Subscribers)
                .Include(t => t.RelatedPosts)
                .Where(searchMethod).ToList();
        }

        public bool Add(Tag entity)
        {
            _dataContext.Tags.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _dataContext.Tags.Remove(Get(id));
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(int id, Tag entity)
        {
            Tag t = Get(id);

            if (t != null)
            {
                t.Name = entity.Name;
                t.Subscribers = entity.Subscribers;
                t.RelatedPosts = entity.RelatedPosts;

                _dataContext.Tags.Update(t);
            }

            return _dataContext.SaveChanges() > 0;
        }
    }
}