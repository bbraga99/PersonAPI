using System.Collections.ObjectModel;

namespace ApiPessoas.Models
{
    public class Adress
    {
       /* public Adress()
        {
            Persons = new Collection<Person>();
        }*/

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
       // public ICollection<Person> person {  get; set; }
       // public Collection<Person> Persons { get; }
    }
}
