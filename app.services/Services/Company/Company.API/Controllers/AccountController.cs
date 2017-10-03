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
    [RoutePrefix("account/v1")]
    public class AccountController : ApiController
    {
        private readonly Lazy<IAccountRepository> _accountRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountRepository"></param>
        public AccountController(Lazy<IAccountRepository> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// Get User Accounts
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Account>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(string))]
        public IHttpActionResult getByName(string name)
        {
            List<Account> accounts = _accountRepository.Value.getByName(name);
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

      
    }
}
