namespace TryitterSolution.WebAPI.Extensions
{
    public class PostNotExistsException: Exception
    {
        public PostNotExistsException(string message)
           : base(message)
        { }
    }
}
