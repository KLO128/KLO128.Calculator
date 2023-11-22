using KLO128.Calculator.Application.Contracts;
using KLO128.Calculator.Application.Web;
using KLO128.Calculator.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Text.Json;

namespace KLO128.Calculator.Presentation.WebApi.Controllers
{
    public static class ControlerExt
    {
        public static TService? TryGetService<TService>(this HttpContext httpContext) where TService : class
        {
            if (httpContext.RequestServices.GetService(typeof(TService)) is TService service)
            {
                return service;
            }

            return null;
        }

        public static string GetSetCultureStringOrDefault(this ControllerBase controller, string culture)
        {
            if (controller.HttpContext.TryGetService<IStringLocalizer>() is not IStringLocalizer localizer || controller.HttpContext.TryGetService<IConfiguration>() is not IConfiguration configuration)
            {
                return Constants.DefaultCulture;
            }

            var ret = culture ?? configuration[Constants.AppSettingKeys.DefaultCulture];
            if (localizer is MyLocalizer ml)
            {
                ml.CultureString = ret;
            }

            return ret;
        }

        public static void AddAccessCookieIfNotNull(this ControllerBase controller, string? accessToken, int expiration)
        {
            if (accessToken != null)
            {
                var expirationDate = DateTime.Now.AddDays(expiration);
                controller.Response.Cookies.Delete(Constants.WebApi.AccessToken);
                controller.Response.Cookies.Delete(Constants.WebApi.CookieExpiration);
                controller.Response.Cookies.Append(Constants.WebApi.AccessToken, accessToken, new CookieOptions { Expires = expirationDate });
                controller.Response.Cookies.Append(Constants.WebApi.CookieExpiration, expirationDate.ToString("yyyy-MM-dd HH-mm:ss"), new CookieOptions { Expires = expirationDate });
            }
        }

        public static IActionResult GetApiResult<T>(this ControllerBase controller, T val)
        {
            if (controller.HttpContext.TryGetService<IConfiguration>() is not IConfiguration configuration || !int.TryParse(configuration[Constants.AppSettingKeys.CookiesExpirationDays], out int expiration))
            {
                expiration = 30;
            }

            if (val is ServiceResult sr && !sr.Succeeded && sr.Error != null && controller.HttpContext.TryGetService<ILogger>() is ILogger logger)
            {
                logger.LogError(sr.Error);
                return controller.Problem(sr.Error.Message, statusCode: 400);
            }

            if (DateTime.TryParse(controller.Request.Cookies[Constants.WebApi.CookieExpiration], out DateTime expirationDate))
            {
                var now = DateTime.Now;
                if (now.AddDays(expiration / 2) < expirationDate)
                {
                    controller.AddAccessCookieIfNotNull(controller.Request.Cookies[Constants.WebApi.AccessToken], expiration);
                }
            }

            var options = new JsonSerializerOptions
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return new JsonResult(val, options);
        }

        public static void LogError(this ILogger logger, Exception exception)
        {
            logger.LogError(new EventId(), exception, exception.Message);
        }
    }
}
