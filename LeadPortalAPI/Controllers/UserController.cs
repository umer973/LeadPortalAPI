
namespace LeadPortalAPI.Controllers
{
    using System.Web.Http;
    using BusinessData;
    using System.Data;
    using BusinessData.Models;

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
        public IHttpActionResult GetUsers(long userId)
        {
            return Ok(ibusiness.GetUsers(userId));
        }

        [Route("api/CreateUser")]
        public IHttpActionResult POST(Users user)
        {
            return Ok(ibusiness.CreateUser(user));
        }

        [HttpPost]
        [Route("api/PostLogin")]
        public IHttpActionResult PostLogin(Users user)
        {
            return Ok(ibusiness.GetLogin(user));
        }
    }
}
