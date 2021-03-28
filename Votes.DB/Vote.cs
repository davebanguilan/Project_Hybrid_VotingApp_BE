using System;
using System.ComponentModel.DataAnnotations;

namespace Votes.DB
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Choice { get; set; }
        public string Count { get; set; }
        public string Creator { get; set; }
        public string Voter { get; set; }
    }
}
