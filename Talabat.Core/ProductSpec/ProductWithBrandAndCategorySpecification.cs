using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Specifications;

namespace Talabat.Core.ProductSpec
{
    public class ProductWithBrandAndCategorySpecification:BaseSpecification<Product>
    {
        public ProductWithBrandAndCategorySpecification(ProductSpecParams param) : base(P =>
        
            (!param.BrandId.HasValue || P.ProductBrandId== param.BrandId)
            &&
            (!param.TypeId.HasValue || P.ProductCategryId==param.TypeId)
        )
        {
            Includes.Add(P => P.ProductCategory);
            Includes.Add(P => P.ProductBrand);
            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P => P.Price);
                        break;

                    case "PriceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;

                    default:
                        AddOrderBy(P => P.Name);
                        break;




                }
            }

            ApplyPagination(param.PageSize * (param.PageIndex - 1), param.PageSize);


        }
        public ProductWithBrandAndCategorySpecification(int id):base(P=>P.Id==id)
        {

            Includes.Add(P => P.ProductCategory);
            Includes.Add(P => P.ProductBrand);

        }

    }
}
