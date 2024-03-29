﻿using MVCWithWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVCWithWebAPI.Controllers
{
    public class EmployeesApiController : ApiController
    {
        private readonly IEmployeeRepository _iEmployeeRepository = new EmployeeRepository();

        [HttpGet]
        [Route("api/Employees/Get")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _iEmployeeRepository.GetEmployees();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Add(employee);
            }
        }

        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public async Task<Employee> Details(string id)
        {
            var result = await _iEmployeeRepository.GetEmployee(id);
            return result;
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public async Task EditAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Update(employee);
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _iEmployeeRepository.Delete(id);
        }
    }
}