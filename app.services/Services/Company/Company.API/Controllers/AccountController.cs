using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using Company.BL.Interfaces;
using app.entities;

namespace Company.Api.Controllers
{/// <summary>
/// 
/// </summary>
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        private readonly Lazy<IAccount> _account;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        public AccountController(Lazy<IAccount> account)
        {
            _account = account;
        }
        /// <summary>
        /// Get User Accounts
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<account>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(string))]
        public IHttpActionResult getByName(string name)
        {
            return Ok(_account.Value.getByName(name));
        }

      
    }
}
