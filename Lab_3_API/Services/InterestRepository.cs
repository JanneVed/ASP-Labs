using Lab_3_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Services
{
    public class InterestRepository : ILab3<Interest>
    {
        private Lab_3_API_DbContext _lab_3_API_DbContext;

        public InterestRepository(Lab_3_API_DbContext lab_3_API_DbContext)
        {
            _lab_3_API_DbContext = lab_3_API_DbContext;
        }

        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _lab_3_API_DbContext.Interests.AddAsync(newEntity);
            await _lab_3_API_DbContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<Interest> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _lab_3_API_DbContext.Interests.Include(pi => pi.PersonInterests).ThenInclude(p => p.Person).ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _lab_3_API_DbContext.Interests.Include(pi => pi.PersonInterests).ThenInclude(p => p.Person).FirstOrDefaultAsync(i => i.InterestId == id);
        }

        public IEnumerable<Interest> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Update(Interest Entity)
        {
            throw new NotImplementedException();
        }
    }
}
