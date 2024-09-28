using System.Collections;

namespace Users
{
    public class User:IComparer
    {
        public string Login { get; set; }

        public int Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        int IComparer.Compare(object a, object b)
        {
            User c1 = (User)a;
            User c2 = (User)b;
            if (c1.Password == c2.Password)
            {
                return 0;
            }
            else if (c1.Password < c2.Password)
            {
                return -1;
            }
            return 1;

        }
    }
}