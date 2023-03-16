namespace KIDApp
{
 public class DeveloperRepo
{
    private readonly List<Developer> _developersList = new List<Developer>();


// ADD DEVELOPERS
    public Boolean AddMembersToList(Developer person)
    {
        int startingCount = _developersList.Count;

        _developersList.Add(person);

        bool SuccessfullyAdded = _developersList.Count > startingCount;

        return SuccessfullyAdded;
    }


// READ LSIT OF PEOPLE
    public List<Developer> GetAllDevelopers() 
    {
        return _developersList;
    }


// FIND A DEVELOPER by ID number(NOI)
    public Developer FindDeveloperNOI(int nOI) 
    {
        foreach(Developer person in _developersList) 
        {
            if (person.NOI == nOI)
            {
                return person;
            }

        }

        return default;
    }

    // FIND A DEVELOPER by NAME (DevName)
    public Developer FindDeveloperName(string devName) 
    {
        foreach(Developer person in _developersList) 
        {
            if (person.DevName.ToLower() == devName.ToLower())
            {
                return person;
            }

        }

        return default;
    }


// FIND DEVELOPERS WHO HAVE ACCESS TO PLURALSIGHT (HasPSAccess)
    public List<Developer> FindDevelopersWithAccess() 
    {
        List<Developer> membersWithAccess = new List<Developer>();//Creates list to gather people. List no longer exists after return

        foreach(Developer person in _developersList) 
        {
            if (person.HasPSAccess)
            {
                membersWithAccess.Add(person);
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

}
}