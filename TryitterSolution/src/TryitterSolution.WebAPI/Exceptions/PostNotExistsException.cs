namespace TryitterSolution.WebAPI.Exceptions
{
    public class PostNotExistsException: Exception
    {
        public PostNotExistsException(string message)
           : base(message)
        { }
    }
}
