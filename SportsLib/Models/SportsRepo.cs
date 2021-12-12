using SportsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsLib.Models
{
    public class SportsRepo : ISportsRepo
    {
        public List<ISport> SportsList { get; set; }
        public void AddSport(ISport _sport)
        {
            throw new NotImplementedException();
        }
        public void RemoveSport(ISport _sport)
        {
            throw new NotImplementedException();
        }
    }
}
