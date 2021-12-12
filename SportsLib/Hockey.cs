using SportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsLib
{
    public class Hockey : Sport
    {
        public Hockey() : base()
        {
            base.Name = "Hockey";
            base.Description = "Soccer on Ice";
        }
    }
}