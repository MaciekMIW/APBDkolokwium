using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDkol2B.Models.DTO
{
    public class MusicianToReturn
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public IEnumerable<Track> TrackList { get; set; }

    }
}
