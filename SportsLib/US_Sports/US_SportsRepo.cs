using SportsLib.Interfaces;
using SportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsLib.US_Sports
{
    public class US_SportsRepo : SportsRepo
    {
        public US_SportsRepo(): base() { }
        public US_SportsRepo(List<ISport> _sportsList) : base(_sportsList) { }
    }
}
