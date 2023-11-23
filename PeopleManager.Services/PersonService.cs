using PeopleManager.Core;
using PeopleManager.Model;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Person> Find()
        {
            return _dbContext.People
                .ToList();
        }

        public Person? Get(int id)
        {
            return _dbContext.People
                .FirstOrDefault(p => p.Id == id);
        }

        public Person? Create(Person person)
        {
            _dbContext.People.Add(person);
            _dbContext.SaveChanges();

            return person;
        }

        public Person? Update(int id, Person person)
        {
            var dbPerson = _dbContext.People.FirstOrDefault(p => p.Id == id);

            if (dbPerson is null)
            {
                return null;
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;

            _dbContext.SaveChanges();

            return person;
        }

        public void Delete(int id)
        {
            var dbPerson = _dbContext.People.FirstOrDefault(p => p.Id == id);

            if (dbPerson is null)
            {
                return;
            }

            _dbContext.People.Remove(dbPerson);

            _dbContext.SaveChanges();
        }
    }
}
