using APBDkol2B.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDkol2B.Services
{
    interface IDbService
    {
        Task<MusicianToReturn> GetMusician(int id);
        Task<bool> CheckIfMusicianExists(int id);
    }
}
