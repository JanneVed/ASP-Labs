using Lab_3_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Services
{
    public class PersonRepository : ILab3<Person>
    {
        private Lab_3_API_DbContext _Lab_3_API_DbContext;

        public PersonRepository(Lab_3_API_DbContext lab_3_API_DbContext)
        {
            this._Lab_3_API_DbContext = lab_3_API_DbContext;
        }

        public async Task<Person> Add(Person newEntity)
        {
            var result = await _Lab_3_API_DbContext.People.AddAsync(newEntity);
            await _Lab_3_API_DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _Lab_3_API_DbContext.People.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _Lab_3_API_DbContext.People.Remove(result);
                await _Lab_3_API_DbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _Lab_3_API_DbContext.People.Include(pi => pi.PersonInterests).ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _Lab_3_API_DbContext.People.Include(pi => pi.PersonInterests).ThenInclude(i => i.Interest)
                .FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await _Lab_3_API_DbContext.People.FirstOrDefaultAsync(p => p.PersonId == Entity.PersonId);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Number = Entity.Number;

                await _Lab_3_API_DbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        IEnumerable<Person> ILab3<Person>.Search(string name)
        {
            IQueryable<Person> query = _Lab_3_API_DbContext.People.Include(pi => pi.PersonInterests).ThenInclude(i => i.Interest);
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.FirstName.Contains(name));
            }
            return query.ToList();
        }
    }
}
