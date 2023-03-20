using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace KIDApp 
{
   public class DevTeam
    {
        public string TeamName {get; set;}
        public List<Developer> Members = new List<Developer>();
        public int TeamNOI {get; set;}

        public DevTeam() {}

        public DevTeam(string teamName, int teamNOI, List<Developer> members) 
        {
            TeamName = teamName;
            TeamNOI = teamNOI;
            Members = members;
            
            
        }

        public DevTeam(string teamName, int teamNOI)
        {
            TeamName = teamName;
            TeamNOI = teamNOI;

        }

        public void AddDevToTeam (Developer developer)
        {
            this.Members.Add(developer);
        }

        public void RemoveDevFromTeam (Developer developer)
        {
            this.Members.Remove(developer);
        }
    }
}