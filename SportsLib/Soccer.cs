using SportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib
{
    public class Soccer : Sport
    {
        public Soccer()
        {
            base.Name = "Soccer";
            base.Description = "Its like a foosball table in real life.";
        }
    }
}