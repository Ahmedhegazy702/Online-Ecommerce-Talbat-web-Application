using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data.Config;

namespace Talabat.Repository.Repository.Implmented
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity

    {
        private readonly StoreContext _dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //if(typeof(T)==typeof(Product))
            //    return(IReadOnlyList<T>)await _dbcontext
            //        .Products.Include(P=>P.ProductBrand)
            //        .Include(P=>P.ProductCategory)
            //        .ToListAsync();
            return await _dbcontext.Set<T>().ToListAsync();

            
        }

     

        public async Task<T?> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
            
        }

        public async Task<T> GetByIdWithSpecasync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        private IQueryable<T>ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_dbcontext.Set<T>(), spec);
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}
