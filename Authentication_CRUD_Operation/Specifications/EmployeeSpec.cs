using Authentication_CRUD_Operation.Model;
using Authentication_CRUD_Operation.Specifications.Base;

namespace Authentication_CRUD_Operation.Specifications
{
    public class EmployeeSpec : BaseSpecification<Employee>
    {
        public EmployeeSpec(string? name, string? email, double? salary, int skip = 0, int take = 10)
        {
            // add filter to the query using aggregate root
            if (!string.IsNullOrEmpty(name))
            {
                AddCriteria(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(email))
            {
                AddCriteria(x => x.Email == email);
            }
            if (salary != null)
            {
                AddCriteria(x => x.Salary == salary);
            }

            // add include to the query using aggregate root


            // add order by to the query using aggregate root
            //AddOrderByAsc(x=> x.Name);

            //ApplyPagination(skip, take);


        }

    }
}
