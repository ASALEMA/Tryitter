namespace TryitterSolution.WebAPI.Extensions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException( string message) 
            : base(message)
        { }
    }
}
