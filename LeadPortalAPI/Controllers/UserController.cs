
namespace LeadPortalAPI.Controllers
{
    using System.Web.Http;
    using BusinessData;
    using System.Data;

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
        public IHttpActionResult POST(DataTable dt)
        {
            return Ok(ibusiness.CreateUser(dt.Rows[0]));
        }
    }
}
