using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace KIDApp
{
    public class DevTeamRepo
    {

        public List<DevTeam> _devTeamList = new List<DevTeam>();

    //CREATE
        public void AddTeamToList(DevTeam devTeam)
        {
            _devTeamList.Add(devTeam);
        }


    //READ
        public List<DevTeam> GetTeamList()
        {
            return _devTeamList;
        }

    //UPDATE
        public bool UpdateDevTeam (int oldDevTeam, DevTeam newInfo)
        {
            DevTeam oldTeamInfo = GetTeamByNOI(oldDevTeam);
            if (oldTeamInfo != null)
            {
                oldTeamInfo.TeamName = newInfo.TeamName;
                oldTeamInfo.TeamNOI = newInfo.TeamNOI;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool RemoveTeam(int teamNOI)
        {
            DevTeam teamID = GetTeamByNOI(teamNOI);
            if (teamID == null)
            {
                return false;
            }

            int startingCount = _devTeamList.Count;
            _devTeamList.Remove(teamID);

            if (startingCount > _devTeamList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DevTeam GetTeamByNOI(int teamIDNum)
        {
            foreach (DevTeam devTeam in _devTeamList)
            {
                if(devTeam.TeamNOI == teamIDNum)
                {
                    return devTeam;
                }
            }

            return null;
        }

        public bool VerifyTeam(int teamNOI)
        {
            return (GetTeamByNOI(teamNOI) != null);
        }
        
    }
}