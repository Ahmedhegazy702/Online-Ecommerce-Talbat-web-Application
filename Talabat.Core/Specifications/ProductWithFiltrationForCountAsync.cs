using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class ProductWithFiltrationForCountAsync:BaseSpecification<Product>
    {
        public ProductWithFiltrationForCountAsync(ProductSpecParams param):base(P =>

            (!param.BrandId.HasValue || P.ProductBrandId == param.BrandId)
            &&
            (!param.TypeId.HasValue || P.ProductCategryId == param.TypeId))
        
        {

            
        }
    }
}
