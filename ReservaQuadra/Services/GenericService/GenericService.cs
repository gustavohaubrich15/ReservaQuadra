using Microsoft.Extensions.Configuration;

namespace ReservaQuadra.Services.GenericService
{
    public abstract class GenericService<T>
    {
        protected readonly ILogger<T> _logger;
        protected readonly IConfiguration _configuration;

        public GenericService(ILogger<T> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}
