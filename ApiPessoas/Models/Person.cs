using ApiPessoas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiPessoas.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
       // public Adress adress { get; set; }
    }
}
