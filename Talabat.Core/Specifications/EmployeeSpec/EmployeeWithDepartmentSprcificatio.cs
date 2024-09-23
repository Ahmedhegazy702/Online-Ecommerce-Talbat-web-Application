using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications.EmployeeSpec
{
    public class EmployeeWithDepartmentSprcificatio:BaseSpecification<Employee>
    {
        public EmployeeWithDepartmentSprcificatio():base()
        {
            Includes.Add(E => E.Department);

        }
        public EmployeeWithDepartmentSprcificatio(int id):base(E=>E.Id==id)
        {
            Includes.Add(E=>E.Department);
        }
    }
}
