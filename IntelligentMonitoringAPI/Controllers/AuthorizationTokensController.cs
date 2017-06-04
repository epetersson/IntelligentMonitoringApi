using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;
using IntelligentMonitoringAPI.Models.Wrappers;

namespace IntelligentMonitoringAPI.Controllers
{
    public class AuthorizationTokensController : ApiController
    {
        private IntelliMonDbContext _context;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public AuthorizationTokensController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Get the current authorization token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAuthorizationToken()
        {
            var authorizationTokens = _context.AuthorizationTokens.FirstOrDefault();

            var response = new AuthorizationTokensWrapper {AuthorizationToken = authorizationTokens};

            return Ok("Not available right now! Only authorized users!");
        }

        /// <summary>
        /// Creates an authorization token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateAuthorizationToken(string token)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorizationToken = new AuthorizationToken(token);

            if (!_context.AuthorizationTokens.Any())
            {
                _context.AuthorizationTokens.Add(authorizationToken);
                _context.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + token), authorizationToken);
            }
            else
            {
                return BadRequest("There is already a token present. There may only be one token. If you wish to update please use the update method intsted");
            }
        }

        /// <summary>
        /// Updates the current authorization token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateAuthorizationToken(string token)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorizationToken = _context.AuthorizationTokens.SingleOrDefault();

            if (authorizationToken == null)
                return CreateAuthorizationToken(token);

            authorizationToken.Token = token;

            _context.Entry<AuthorizationToken>(authorizationToken).CurrentValues.SetValues(authorizationToken);

            _context.SaveChanges();

            return Ok("The token was successfully updated!");

        }

        /// <summary>
        /// Deletes the current token
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteAuthorizationToken()
        {
            var authorizationToken = _context.AuthorizationTokens.SingleOrDefault();

            if (authorizationToken == null)
                return NotFound();

            _context.AuthorizationTokens.Remove(authorizationToken);
            _context.SaveChanges();

            return Ok("The ");
        }
    }
}
