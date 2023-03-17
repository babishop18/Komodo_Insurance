//namespace KIDApp
//{
public class Developer
    {
        public string DevName {get; set;}

        public int NOI {get; set;}
        //NOI = number of identification

        public bool HasPSAccess {get; set;}

        public Developer() {}

        public Developer(string devName, int nOI, bool hasPSAccess) 
        {
            DevName=devName;
            NOI=nOI;
            HasPSAccess = hasPSAccess;
        }

    }
//}