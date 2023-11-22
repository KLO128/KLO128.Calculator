using KLO128.Calculator.Domain.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KLO128.Calculator.Presentation.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public ILogger Logger { get; set; }

        public ErrorController(ILogger Logger)
        {
            this.Logger = Logger;
        }

        [HttpGet]
        [Route("error")]
        public IActionResult Error(int? id)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            if (exception == null)
            {
                return Problem($"500 {HttpStatusCode.InternalServerError}");
            }

            if (exception is UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            else if ((id ?? null) == null)
            {
                if (exception is Warning)
                {
                    id = (int)HttpStatusCode.BadRequest;
                }
            }

            Logger.LogError(exception);

            return Problem(exception.Message, statusCode: id ?? Response.StatusCode);
        }

    }
}
