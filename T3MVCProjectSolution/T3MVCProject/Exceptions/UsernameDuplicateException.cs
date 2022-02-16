namespace T3MVCProject.Exceptions
{
    public class UsernameDuplicateException : Exception
    {

        string msg;
        public UsernameDuplicateException()
        {
            msg = "This Username has been registered to another account.";
        }
        public override string Message => msg;
    }
}
