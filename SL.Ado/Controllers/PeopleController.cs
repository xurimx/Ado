using Microsoft.AspNetCore.Mvc;
using SL.Domain.Entities;
using SL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SL.Ado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IGenericRepository<Person> repository;

        public PeopleController(IGenericRepository<Person> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await repository.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<Person> GetAsync(Guid id)
        {
            return await repository.FindById(id);
        }

        [HttpPost]
        public async Task<Person> PostAsync(Person person)
        {
            if (person.Id == Guid.Empty)
            {
                person.Id = Guid.NewGuid();
            }

            await repository.Insert(person);
            return person;
        }
    }
}
