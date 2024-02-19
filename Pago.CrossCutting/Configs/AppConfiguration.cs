using Microsoft.Extensions.Configuration;

namespace Pago.CrossCutting.Configs
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConexionDBPagos
        {
            get
            {
                return _configuration["dbPago-cnx"];
            }
            private set { }
        }

    }
}
