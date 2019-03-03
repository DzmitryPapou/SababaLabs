using System;

namespace FinalTask.ComputerScience.Logic
{
    public class GetMusicException : Exception
    {
        public GetMusicException()
        {
        }

        public GetMusicException(string message)
            : base(message)
        {

        }

        public GetMusicException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetFriendsException : Exception
    {
        public GetFriendsException()
        {
        }

        public GetFriendsException(string message)
            : base(message)
        {
        }

        public GetFriendsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class AuthentificateException : Exception
    {
        public AuthentificateException(string message)
             : base(message)
        {

        }

        public AuthentificateException()
        {

        }

        public AuthentificateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class RestClientException : Exception
    {
        public RestClientException()
        {
        }

        public RestClientException(string message)
            : base(message)
        {

        }

        public RestClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
   
}
