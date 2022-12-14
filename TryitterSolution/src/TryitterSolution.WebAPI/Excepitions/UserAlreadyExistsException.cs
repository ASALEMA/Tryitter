namespace TryitterSolution.WebAPI.Excepitions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message)
            : base(message)
        { }
    }
}
