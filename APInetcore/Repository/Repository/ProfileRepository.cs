using Microsoft.EntityFrameworkCore;
using Repository.EF;
using Repository.Interface;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository() : base() { }
        public async Task<int> AddAsync(Profile profile)
        {
            await _db.Profiles.AddAsync(profile);
            await _db.SaveChangesAsync();
            return profile.Id;
        }

        public async void Delete(Profile profile)
        {
            _db.Profiles.Remove(profile);
            await _db.SaveChangesAsync();
        }

        public async Task<Profile> GetByIdAsync(int id)
        {
            return await _db.Profiles.FindAsync(id);
        }

        public async Task<QueryListResult<Profile>> GetListAsync(QueryParram parram)
        {
            IQueryable<Profile> queryProfile = _db.Profiles.AsNoTracking(); 
            List<Profile> profiles = await queryProfile.Skip(parram.Page - 1 * parram.Limit).Take(parram.Limit).ToListAsync<Profile>();
            int totalProfile = await queryProfile.CountAsync();
            return new QueryListResult<Profile>(profiles, totalProfile);
        }

        public async void Update(Profile profile)
        {
            _db.Profiles.Update(profile);
            await _db.SaveChangesAsync();
        }
    }
}
