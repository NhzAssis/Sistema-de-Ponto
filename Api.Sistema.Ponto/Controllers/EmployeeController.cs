using Api.Sistema.Ponto.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Sistema.Ponto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Repository repository;
        public EmployeeController()
        {
            repository = new Repository();

        }

        //Get All
        [HttpGet]
        [Route("Get")]

        public IEnumerable<LoginModel> GetAll()
        {
            return repository.GetAll();

        }

        //Get Id
        [HttpGet]
        [Route("Get/{Id}")]
        public LoginModel GetById(int Id)
        {
            return repository.GetById(Id);

        }


        //Insert
        [HttpPost]


        public void Post([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
                repository.add(loginModel);
        }


        //Update
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] LoginModel loginModel)
        {
            loginModel.Id = Id;
            if (ModelState.IsValid)
                repository.Update(loginModel);
        }

        //Delete
        [HttpDelete]

        public void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
