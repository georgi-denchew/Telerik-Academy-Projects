using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumDb.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
