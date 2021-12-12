using SportsLib.Interfaces;
using SportsLib.Models;
using SportsLib.US_Sports;
using SportsMVC.Models;
using System.Collections.Generic;

namespace SportsMVC.ViewModels
{
    public class AdminViewModel
    {
        public ISportsRepo repo;

        public AdminViewModel(ISportsRepo _repo)
        {
            this.repo = _repo;
        }
    }
}
