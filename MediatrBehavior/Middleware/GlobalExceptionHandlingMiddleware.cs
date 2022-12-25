using System.Net;
using System.Text.Json;

namespace MediatrBehavior.Middleware
{
	public class GlobalExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";

			var exModel = new { responseCode = (int)HttpStatusCode.BadRequest, responseMessage = exception.InnerException.Message };

			string exResult = JsonSerializer.Serialize(exModel);
			await context.Response.WriteAsync(exResult);
		}
	}
}