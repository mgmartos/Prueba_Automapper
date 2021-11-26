using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.Middlewares
{
    public class EjemploMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public EjemploMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(EjemploMiddleware));

            //ILoggerFactory factory = new LoggerFactory().AddConsole();    // add console provider
            //factory.AddProvider(new LoggerFileProvider("c:\\log.txt"));   // add file provider
            //Logger logger = factory.CreateLogger(); // <-- creates a console logger and a file logger


        }



        public async Task Invoke(HttpContext context)
        {
            Guid traceId = Guid.NewGuid();
          //  _logger.LogInformation($"Request {traceId} iniciada");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsdtime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
           // _logger.LogInformation($"La request {traceId} ha llevado {elapsdtime} ");
            //_logger.LogError($"La request {traceId} ha llevado {elapsdtime} ");
            //_logger.LogDebug($"La request {traceId} ha llevado {elapsdtime} ");
            //_logger.LogTrace($"La request {traceId} ha llevado {elapsdtime} ");
            //_logger.LogCritical($"La request {traceId} ha llevado {elapsdtime} ");
         }

    }
}
