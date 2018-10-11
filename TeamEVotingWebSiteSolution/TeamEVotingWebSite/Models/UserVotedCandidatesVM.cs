using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamEVotingWebSite.Models
{
    public class UserVotedCandidatesVM
    {

        public int User_Id { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public int Candidate_Id { get; set; }
        public string Candidate_FirstName { get; set; }
        public int Candidate_Age { get; set; }
        public string Candidate_LastName { get; set; }

    }
}