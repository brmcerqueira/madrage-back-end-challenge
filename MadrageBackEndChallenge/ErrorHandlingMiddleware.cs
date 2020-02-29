using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MadrageBackEndChallenge.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace MadrageBackEndChallenge.Web
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IStringLocalizer stringLocalizer)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                object result = null;

                if (exception is ValidationException validationException)
                {
                    result = new
                    {
                        Message = stringLocalizer[validationException.Message].Value,
                        ErrorCode = validationException.Code,
                        validationException.Errors
                    };
                }
                else if(exception is MadrageBackEndChallengeException madrageBackEndChallengeException)
                {
                    result = new
                    {
                        Message = stringLocalizer[madrageBackEndChallengeException.Message].Value,
                        ErrorCode = madrageBackEndChallengeException.Code
                    };
                }
                else
                {
                    result = new
                    {
                        Message = stringLocalizer["SystemUnavailable"].Value,
                        ErrorCode = 0
                    };
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}