using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace DevSkillHQ_BE.Controllers
{
    public class CustomActionResult : IActionResult
    {

        private readonly HttpStatusCode _statusCode;
        private readonly string _message;

        public CustomActionResult(HttpStatusCode status, string message)
        {
            _statusCode = status;
            _message = message;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new
            {
                Message = _message
            })
            {
                StatusCode = (int)_statusCode,
            };

            context.HttpContext.Features.Get<IHttpResponseFeature>()!.ReasonPhrase = _message;

            await objectResult.ExecuteResultAsync(context);
        }
    }
}