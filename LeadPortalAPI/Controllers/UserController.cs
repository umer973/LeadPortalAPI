
namespace LeadPortalAPI.Controllers
{
    using System.Web.Http;
    using BusinessData;
    public class UserController : ApiController
    {
        IBusinessData ibusiness;

        public UserController()
        {
            ibusiness = new BusinessData();
        }

        public IHttpActionResult GET()
        {
            return Ok("API is running");
        }

        [Route("api/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            return Ok(ibusiness.GetUsers());
        }

        [Route("api/CreateUser")]
        public IHttpActionResult POST()
        {
            return Ok(ibusiness.CreateUser());
        }
    }
}
