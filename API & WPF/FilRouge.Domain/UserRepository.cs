using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilRouge.Repositories.Interfaces;
using FilRouge.Classes;
using FilRouge.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public User Get(int id)
        {
            return _dataContext.Users
                .Include(u => u.FavoriteTags)
                .Include(u=>u.Posts)
                .Include(u=>u.Answers)
                .Include(u=>u.Comments)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _dataContext.Users
                .Include(u => u.FavoriteTags)
                .Include(u=>u.Posts)
                .Include(u=>u.Answers)
                .Include(u=>u.Comments)
                .ToList();
        }

        public User Search(Expression<Func<User, bool>> searchMethod)
        {
            return _dataContext.Users
                .Include(u => u.FavoriteTags)
                .Include(u=>u.Posts)
                .Include(u=>u.Answers)
                .Include(u=>u.Comments)
                .FirstOrDefault(searchMethod);
        }

        public List<User> SearchAll(Expression<Func<User, bool>> searchMethod)
        {
            return _dataContext.Users
                .Include(u => u.FavoriteTags)
                .Include(u=>u.Posts)
                .Include(u=>u.Answers)
                .Include(u=>u.Comments)
                .Where(searchMethod).ToList();
        }

        public bool Add(User entity)
        {
            _dataContext.Users.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _dataContext.Users.Remove(Get(id));
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(int id, User entity)
        {
            User u = Get(id);

            if (u != null)
            {
                u.Username = entity.Username;
                u.Email = entity.Email;
                u.LastName = entity.LastName;
                u.FirstName = entity.FirstName;
                u.IsBlacklisted = entity.IsBlacklisted;
                u.FavoriteTags = entity.FavoriteTags;
                u.Answers = entity.Answers;
                u.Comments = entity.Comments;
                u.Posts = entity.Posts;
                u.RegisterAt = entity.RegisterAt;
                u.AvatarPath = entity.AvatarPath;
                u.Password = entity.Password;
            }

            return _dataContext.SaveChanges() > 0;
        }
    }
}