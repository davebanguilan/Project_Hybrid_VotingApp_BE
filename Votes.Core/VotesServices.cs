using System;
using System.Collections.Generic;
using System.Linq;
using Votes.DB;

namespace Votes.Core
{
    public class VotesServices : IVotesServices
    {
        private AppDbContext _context;
        public VotesServices(AppDbContext context)
        {
            _context = context;
        }

        public Vote CreateVote(Vote vote)
        {
            _context.Add(vote);
            _context.SaveChanges();

            return vote;
        }

        public void DeleteVote(Vote vote)
        {
            _context.Votes.Remove(vote);
            _context.SaveChanges();
        }

        public Vote EditVote(Vote vote)
        {
            var dbVote = _context.Votes.First(e => e.Id == vote.Id);
            dbVote.Question = vote.Question;
            dbVote.Choice = vote.Choice;
            dbVote.Count = vote.Count;
            dbVote.Creator = vote.Creator;
            dbVote.Voter = vote.Voter;
            _context.SaveChanges();

            return dbVote;
        }

        public Vote GetVote(int id)
        {
            return _context.Votes.First(e => e.Id == id);
        }

        public List<Vote> GetVotes()
        {
            return _context.Votes.ToList();
        }
    }
}
