using APBDkol2B.Models;
using APBDkol2B.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDkol2B.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MusicianToReturn> GetMusician(int id)
        {
            //get musician
            var musician = await _dbContext.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            //get tracks
            
            //MusicianToReturn result = 
            return new MusicianToReturn
            {
                FirstName = musician.FirstName,
                LastName = musician.LastName,
            };
        }
        public async Task<bool> CheckIfMusicianExists(int id)
        {
            return await _dbContext.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync() == null ? false : true;
        }
    }
}
