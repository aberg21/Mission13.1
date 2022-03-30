using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamsViewComponents : ViewComponent
    {
            
        private BowlingDbContext bowler { get; set; }

            
        public TeamsViewComponents(BowlingDbContext temp)
        {
            bowler = temp;
        }

           
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedTeam = RouteData?.Values["teamName"] ?? "";

                
            var teams = bowler.Bowlers
                .Select(x => x.Team.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
