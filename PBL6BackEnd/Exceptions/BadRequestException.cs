using System.Net;

namespace PBL6BackEnd.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
