using ReservaQuadra.DTO;
using ReservaQuadra.Enumeration;
using ReservaQuadra.Repositories.UserRepository;
using ReservaQuadra.Services.GenericService;
using ReservaQuadra.Services.UserService;

namespace ReservaQuadra.Services.CourtService
{
    public class CourtService : GenericService<CourtService>, ICourtService
    {
        public CourtService(
            ILogger<CourtService> logger,
            IConfiguration configuration)
            : base(logger, configuration)
        {
           
        }


        public ResponseModelDTO<IEnumerable<CourtDTO>> GetAllCourts()
        {
            var courts = Enum.GetValues<Court>()
                 .Select(c => new CourtDTO
                 {
                     Court = c
                 });

            return new ResponseModelDTO<IEnumerable<CourtDTO>>
            {
                Data = courts
            };
        }

    }
}
