using ApiPessoas.Context;
using ApiPessoas.Models;
using ApiPessoas.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            try
            {
                var person = _context.Persons.ToList();
                if (person is null)
                {
                    return NotFound("Não há pessoas cadastradas");
                }

                return person;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<IEnumerable<Person>> GetByID(int id)
        {
            try
            {
                var person = _context.Persons.FirstOrDefault(p => p.PersonID == id);
                if (person is null) {
                    return NotFound($"Person with id {id} not found");
                }

                return Ok(person);

            }
            catch (Exception)
            {
                throw new Exception("Houve um erro no sistema");
            }
        }

        [HttpGet("Gender/{Gender}")]
        public ActionResult<IEnumerable<Person>> GetByGender(Gender Gender)
        {
            try
            {
                var persons = _context.Persons.Where(p => p.Gender == Gender);
                if (persons is null)
                {
                    return NotFound("Não foi possivel retornar a lista");
                }

                return Ok(persons);

            }
            catch (Exception)
            {

                throw new Exception("Houve um erro no sistema");
            }
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            try
            {
                if (person is null)
                {
                    return BadRequest("Não foi possivel criar uma nova pessoa");
                }

                _context.Persons.Add(person);
                _context.SaveChanges();

                return new CreatedAtRouteResult("GetPerson", new { id = person.PersonID, person });

            }
            catch (Exception)
            {

                throw new Exception("Houve um erro no sistema");
            }
        }

        [HttpPut("{id}")] 
        public ActionResult Put(int id,Person person)
        {
            try
            {
               if (id != person.PersonID)
                {
                    return NotFound($"Person with id {id} not found");
                }

                _context.Entry(person).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(person);

            }
            catch (Exception)
            {

                throw new Exception("Houve um erro no sistema");
            }


         }

        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            try
            {
                var person = _context.Persons.FirstOrDefault(p => p.PersonID == id);
                if(person is null)
                {
                    return NotFound();
                }

                _context.Persons.Remove(person);    
                _context.SaveChanges();

                return Ok(person);

            }
            catch (Exception)
            {

                throw new Exception("Houve um erro no sistema");
            }
        }

        

    }
}
