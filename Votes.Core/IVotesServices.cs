using Votes.DB;
using System;
using System.Collections.Generic;

namespace Votes.Core
{
    public interface IVotesServices
    {
        List<Vote> GetVotes();
        Vote GetVote(int id);
        Vote CreateVote(Vote vote);
        void DeleteVote(Vote vote);
        Vote EditVote(Vote vote);
    }
}
