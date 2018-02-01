using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace DesafioGuitarras.Controllers
{
    [RoutePrefix("api/EletricGuitar")]
    public class EletricGuitarApiController : ApiController
    {
        private readonly IEletricGuitarService _service;

        public EletricGuitarApiController(IEletricGuitarService service) => _service = service;

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<EletricGuitar> GetAll()
        {
            try
            {
                return _service.GetAll();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public EletricGuitar Get(int id)
        {
            try
            {
                return _service.GetByPrimaryKey(id);
            }
            catch
            {
                return null;
            }
        }
    }
}
