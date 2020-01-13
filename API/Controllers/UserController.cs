using API.Token;
using Common.HttpHelpers;
using Domain;
using Domain.CustomModels;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        UserService service;
        public UserController()
        {
            service = new UserService();
        }
        [Authorize]
        public JsonResult<EResponseBase<User>> GetUsers()
        {
            return Json(service.Get());
        }
        [HttpPost]
        public IHttpActionResult Authenticate(LoginRequest request)
        {
            if (request == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            EResponseBase<User> response = service.Login(request);
            if (response.Status)
            {
                var token = TokenGenerator.GenerateTokenJwt(request.Email);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
