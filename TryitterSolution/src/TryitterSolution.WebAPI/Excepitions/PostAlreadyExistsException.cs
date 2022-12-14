namespace TryitterSolution.WebAPI.Excepitions
{
    public class PostAlreadyExistsException : Exception
    {
        public PostAlreadyExistsException(string message)
           : base(message)
        { }
    }
}
