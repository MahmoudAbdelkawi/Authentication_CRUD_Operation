using Authentication_CRUD_Operation.Dtos;
using Authentication_CRUD_Operation.Globals;
using Authentication_CRUD_Operation.Model;
using Authentication_CRUD_Operation.Repository.Employees;
using Authentication_CRUD_Operation.Specifications;
using Authentication_CRUD_Operation.Specifications.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Authentication_CRUD_Operation.Controllers
{
    public class EmployeeController : BaseController
    {
        // Add CRUD Operation for Employee
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllEmpolyeeDto getAllEmpolyeeDto)
        {
            var employees = _employeeRepository.GetAllAsync();
            var empSpec = new EmployeeSpec(getAllEmpolyeeDto.Name, getAllEmpolyeeDto.Email, getAllEmpolyeeDto.Salary, getAllEmpolyeeDto.Take, getAllEmpolyeeDto.Skip);
            var employeesSpec = SpecificationEvaluator<Employee>.GetQueryWithSpec(employees, empSpec);
            return Result(
                new BaseResponse<List<Employee>>
                {
                    Message = "Success",
                    Data = employeesSpec.ToList(),
                    StatusCode = HttpStatusCode.OK
                }
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return Result(
                    new BaseResponse<Employee>
                    {
                        Message = "Employee not found",
                        StatusCode = HttpStatusCode.NotFound
                    }
                    );
            }
            return Result(
                new BaseResponse<Employee>
                {
                    Message = "Success",
                    Data = employee,
                    StatusCode = HttpStatusCode.OK
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employee)
        {
            var mappedEmployee = _mapper.Map<Employee>(employee);
            var newEmployee = await _employeeRepository.CreateAsync(mappedEmployee);
            return Result(
                new BaseResponse<Employee>
                {
                    Message = "Employee created",
                    Data = newEmployee,
                    StatusCode = HttpStatusCode.Created
                }
           );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EmployeeDto employee)
        {
            var emp = await _employeeRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return Result(
                    new BaseResponse<Employee>
                    {
                        Message = "Employee not found",
                        StatusCode = HttpStatusCode.NotFound
                    }
                );
            }
            var mappedEmployee = _mapper.Map<Employee>(employee);
            var updatedEmployee = await _employeeRepository.UpdateAsync(id, mappedEmployee);
            return Result(
                    new BaseResponse<Employee>
                    {
                        Message = "Employee updated",
                        Data = updatedEmployee,
                        StatusCode = HttpStatusCode.OK
                    }
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return Result(
                                       new BaseResponse<Employee>
                                       {
                        Message = "Employee not found",
                        StatusCode = HttpStatusCode.NotFound
                    }
                                                      );
            }
            var deletedEmployee = await _employeeRepository.DeleteAsync(employee);
            return Result(
                               new BaseResponse<Employee>
                               {
                    Message = "Employee deleted",
                    Data = deletedEmployee,
                    StatusCode = HttpStatusCode.OK
                }
                                          );
        }
    }
}
