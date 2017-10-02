using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using app.entities;
using LoanBL.Interfaces;

namespace UserServices.Controllers
{/// <summary>
/// 
/// </summary>
    [RoutePrefix("accounts")]
    public class AccountController : ApiController
    {
        private readonly Lazy<IAccount> _accounts;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accounts"></param>
        public AccountController(Lazy<IAccount> accounts) {
            _accounts = accounts;
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
            return Ok(_accounts.Value.getByName(name));
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="accountDetails"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(IMongoCollection<BsonDocument>))]
        //[SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(string))]
        //public IHttpActionResult createUserAccount(account accountDetails)
        //{
        //    var connectionString = "mongodb://localhost:27017";

        //    var client = new MongoClient(connectionString);
        //    IMongoDatabase db = client.GetDatabase("company");
        //    IMongoCollection<account> accountCollection = db.GetCollection<account>("accounts");
        //    fuzzySearch.Search(accountName, accountCollection, 0.70);
        //    return Ok(accountCollection);
        //}
    }
}
