using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wyklad5.Services;

namespace Cw3WebApplication.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IStudentsDbService dbService)
        {
            context.Request.EnableBuffering();
            if (context.Request != null)
            {
                string path = context.Request.Path;
                string method = context.Request.Method;
                string queryStr = context.Request.QueryString.ToString();
                string bodyStr = context.Request.Body.ToString();

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }
                // zapisac do pliku / DB
                var filepath = "Logs/requestLog.txt";
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("Method: " + method
                        + ", Path: " + path
                        + ", Request Body: " + bodyStr
                        + ", QueryStr: " + queryStr
                        );
                }
            }

            if (_next != null) await _next(context);
        }

    }
}
