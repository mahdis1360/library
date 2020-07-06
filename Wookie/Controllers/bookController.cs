using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using EfRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poco;

namespace savvyy.Controllers
{
    [Route("api/WookieBooks/book/v1")]
    [ApiController]
    public class bookController : ControllerBase
    {
        private readonly BookLogic _logic;
        public bookController()
        {
            var repo = new EfGenericRepositort<BookPoco>();
            _logic = new BookLogic(repo);
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult Get(Guid id)
        {
            var pocos = _logic.Get(id);

            if (pocos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pocos);
            }

        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search(string detail)
        {
            var pocos = _logic.Search(detail);
            if (pocos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pocos);
            }

        }
    }



}
