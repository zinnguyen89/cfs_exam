using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFS.Common.Responses
{
    public class InternalServerErrorObjectResponse : ObjectResult
    {
        public InternalServerErrorObjectResponse(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
