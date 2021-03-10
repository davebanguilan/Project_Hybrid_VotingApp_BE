using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Votes.Core;
using Votes.DB;

namespace Votes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotesController : ControllerBase
    {
        private IVotesServices _votesServices;
        public VotesController(IVotesServices votesServices)
        {
            _votesServices = votesServices;
        }

        [HttpGet]
        public IActionResult GetVotes() {
            return Ok(_votesServices.GetVotes());
        }

        [HttpGet("{id}", Name = "GetVote" )]
        public IActionResult GetVote(int id)
        {
            return Ok(_votesServices.GetVote(id));
        }

        [HttpPost]
        public IActionResult CreateVote(Vote vote)
        {
            var newVote = _votesServices.CreateVote(vote);

            return CreatedAtRoute("GetVote", new { newVote.Id }, newVote);
        }

        [HttpDelete]
        public IActionResult DeleteVote(Vote vote)
        {
            _votesServices.DeleteVote(vote);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditVote(Vote vote)
        {
            return Ok(_votesServices.EditVote(vote));
        }
    }
}
