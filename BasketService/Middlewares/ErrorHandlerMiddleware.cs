using BasketService.Controllers;
using Business.Localization;
using Core.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace BasketService.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<BasketController> _logger;
        private readonly ILocalizationProvider _localizationProvider;
        private readonly string _validationExceptionKey = "ValidationException";
        private readonly string _unhandledExceptionExceptionKey = "UnknownException";
        private readonly string _businessBaseExceptionPrefix = "BusinessBaseException_";

        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<BasketController> logger,
            ILocalizationProvider localizationProvider)
        {
            _next = next;
            _logger = logger;
            _localizationProvider = localizationProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if (error is BusinessBaseException businessBaseException)
                {
                    response.StatusCode = businessBaseException.StatusCode > 0 ? businessBaseException.StatusCode : 451;
                    var message = _localizationProvider.GetLocalization(
                        _businessBaseExceptionPrefix + businessBaseException.ExceptionKey.ToString(), "tr");
                    var resp = JsonSerializer.Serialize(new { message = message });
                    await response.WriteAsync(resp);
                }
                else if (error is ValidationException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var message = _localizationProvider.GetLocalization(_validationExceptionKey, "tr");
                    var resp = JsonSerializer.Serialize(new { message = message });
                    await response.WriteAsync(resp);
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var message = _localizationProvider.GetLocalization(_unhandledExceptionExceptionKey, "tr");
                    _logger.LogError("Sistem hatası", error);
                    var resp = JsonSerializer.Serialize(new { message = message });
                    await response.WriteAsync(resp);
                }
            }
        }
    }
}
