namespace TryitterSolution.WebAPI.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException( string message) 
            : base(message)
        { }
    }
}
