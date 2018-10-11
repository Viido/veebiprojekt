using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.ViewModels
{
    public class UsersVotedCantidateViewModel
    {
        public UserSet usersVM { get; set; }

        public CandidateSet candidateVM { get; set; }
    }
}