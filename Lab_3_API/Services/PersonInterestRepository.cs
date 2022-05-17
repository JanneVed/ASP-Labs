using Lab_3_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Services
{
    public class PersonInterestRepository : ILab3<PersonInterest>
    {
        private Lab_3_API_DbContext _DbContext;

        public PersonInterestRepository(Lab_3_API_DbContext lab_3_API_DbContext)
        {
            _DbContext = lab_3_API_DbContext;
        }

        public async Task<PersonInterest> Add(PersonInterest newEntity)
        {
            var result = await _DbContext.PersonInterests.AddAsync(newEntity);
            await _DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<PersonInterest> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonInterest>> GetAll()
        {
            return await _DbContext.PersonInterests.Include(p => p.Person).ToListAsync();
        }

        public Task<PersonInterest> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonInterest> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PersonInterest> Update(PersonInterest Entity)
        {
            throw new NotImplementedException();
        }
    }
}
