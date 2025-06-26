using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BancoAPI.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ocurrió un error no manejado.");

				context.Response.StatusCode = 500;
				context.Response.ContentType = "application/json";

				var response = new { message = "Error interno del servidor. Por favor intenta más tarde." };

				await context.Response.WriteAsJsonAsync(response);
			}
		}
	}
}
