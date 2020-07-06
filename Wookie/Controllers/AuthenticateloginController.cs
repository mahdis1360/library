using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using poco;
using BusinessLogicLayer;
using EfRepository;
using Microsoft.AspNetCore.Authorization;

namespace savvyy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateloginController : ControllerBase
    {
        private readonly BookLogic _logic;


        IUserRepository _userRepository;

        public AuthenticateloginController()
        {
            _userRepository = new UserRepository();
            var repo = new EfGenericRepositort<BookPoco>();
            _logic = new BookLogic(repo);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            if (!_userRepository.ValidateLogin(userName, password))
            {

                return BadRequest(" Invalid Login");
            }

            return RedirectToLocal(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Constants.MiddlewareScheme);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Forbidden()
        {
            return BadRequest();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Dlete")]
        public ActionResult DeleteBook(
                [FromBody]Guid id)
        {
            var book = new BookPoco();

            if (book.AutorId != DataAccessLayer.UserRepository.AuthorloginId)
            {
                return BadRequest();
            }
            _logic.Delete(id);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody]BookPoco book)
        {
            _logic.Add(book);
            return Ok();


        }

        [Authorize]
        [HttpPut]
        [Route("Edit")]
        public ActionResult PutApplicantEducationEdit([FromBody]BookPoco book)
        {
            _logic.Update(book);
            return Ok();

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

    }
}