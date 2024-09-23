using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    public static class SpecificationEvalutor<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity>GetQuery(IQueryable<TEntity> inputquery, ISpecification<TEntity> spec) 
        {
            var query = inputquery;
            if(spec.Critera is not null)
            {
                query = query.Where(spec.Critera);
                if(spec.OrderBy is not null)
                {
                    query = query.OrderBy(spec.OrderBy);
                }
                if (spec.OrderByDesc is not null)
                {
                    query = query.OrderBy(spec.OrderByDesc);


                }
                if (spec.IsPaginationEnabled)
                {
                    query=query.Skip(spec.Skip).Take(spec.Take);
                }

                query = spec.Includes.Aggregate(query,(currenqueery,IncludeExpression)=>currenqueery.Include(IncludeExpression));

            }
            return query;
        
        }

    }
}
