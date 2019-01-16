namespace CompanyTaskClass
{
    public class Session
    {
        private static SessionMap<string, string> instance = new SessionMap<string, string>();
        public static SessionMap<string, string> Instance
        {
            get
            {
                if(instance == null)
                    instance = new SessionMap<string, string>();
                return instance;
            }
        }
       
    }
}
