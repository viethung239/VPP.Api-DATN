using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Context;

namespace VPP.Infrastructure.Repositories
{
   
    public class Repo<T> : IRepo<T> where T : class, new()
    {
        private readonly ILogger<Repo<T>> _logger;

        private readonly VPPDBContext _context;
        DbSet<T> _dbSet;

       
        public Repo(VPPDBContext context, ILogger<Repo<T>> logger) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger; 
        }
      
        public List<T> GetAll()
        {
            return _dbSet.ToList(); 
        }

        
        public T Get(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                _logger.LogError($"Không tìm thấy đối tượng với id {id}");
            
            }
            return entity;
        }
        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Đã xảy ra lỗi khi thêm dữ liệu: {ex.Message}");

                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Đã xảy ra lỗi khi chỉnh sửa dữ liệu: {ex.Message}");
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                return false;

            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Đã xảy ra lỗi khi xóa dữ liệu: {ex.Message}");
                return false;
            }
        }
    }
}
