using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Serilog;
using Prueba_Automapper.Interfaces;

namespace Prueba_Automapper.Utils
{
    public  class Loggin : ILogin
    {
        //private  readonly ILogger _logger;
        private readonly ILogger _logger;
        public Loggin(ILoggerFactory loggerfactory)
        {
            _logger = loggerfactory.CreateLogger(typeof(Loggin));
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.File("log.txt")
            ////.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
            //.CreateLogger();
        }

        public void LogInformation(string mensaje)
        {
            this._logger.LogInformation(mensaje);
           // Log.Information(mensaje);
          
        }


    }
}
