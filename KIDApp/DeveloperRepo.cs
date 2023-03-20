using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace KIDApp
{
 public class DeveloperRepo
{
    
    public readonly List<Developer> _developersList = new List<Developer>();
    public readonly List<Developer> membersWithAccess = new List<Developer>();


// ADD DEVELOPERS
    public Boolean AddToDevList(Developer developer)
    {
        int startingCount = _developersList.Count;

        _developersList.Add(developer);

        bool SuccessfullyAdded = _developersList.Count > startingCount;

        return SuccessfullyAdded;
    }


// READ LIST OF PEOPLE
    public List<Developer> GetAllDevelopers() 
    {
        return _developersList;
    }


// FIND A DEVELOPER by ID number(NOI)
    public Developer FindDeveloperNOI(int nOI) 
    {
        foreach(Developer developer in _developersList) 
        {
        if (developer.NOI == nOI)
            {
                return developer;
            }

        }

        return default;
    }

    // FIND A DEVELOPER by NAME (DevName)
    public Developer FindDeveloperName(string devName) 
    {
        foreach(Developer developer in _developersList) 
        {
            if (developer.DevName.ToLower() == devName.ToLower())
            {
                return developer;
            }

        }

        return default;
    }


// FIND DEVELOPERS WHO HAVE ACCESS TO PLURALSIGHT (HasPSAccess)
    public List<Developer> FindDevelopersWithAccess() 
    {
        //List<Developer> membersWithAccess = new List<Developer>();//Creates list to gather people. List no longer exists after return

        foreach(Developer developer in _developersList) 
        {
            if (developer.HasPSAccess)
            {
                membersWithAccess.Add(developer);
            }

        }

        return membersWithAccess;
    }


// UPDATE DEVELOPER INFORMATION
    public bool UpdateDeveloperInfo(int oldInfoByNOI, Developer newInfo) 
    {
        Developer oldInfo = FindDeveloperNOI(oldInfoByNOI);

        if (oldInfo != default)
        {
            oldInfo.DevName = newInfo.DevName;
            oldInfo.NOI = newInfo.NOI;
            oldInfo.HasPSAccess = newInfo.HasPSAccess;
            return true;
        }
        else{return false;}
    }


// DELETE A DEVELOPER AND THEIR INFO
    public bool DeletePerson(int nOI)
    {
        Developer personToDelete = FindDeveloperNOI(nOI);
        
        if (personToDelete != default)
        {
            bool removePerson = _developersList.Remove(personToDelete);
            return removePerson;
        }
        else {return false;}
    }

    public bool VerifyDev(int developerNOI)
    {
        return (FindDeveloperNOI(developerNOI) != null);
    }

    
}
}