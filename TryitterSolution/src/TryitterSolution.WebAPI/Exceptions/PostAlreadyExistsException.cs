﻿namespace TryitterSolution.WebAPI.Exceptions
{
    public class PostAlreadyExistsException : Exception
    {
        public PostAlreadyExistsException(string message)
           : base(message)
        { }
    }
}
