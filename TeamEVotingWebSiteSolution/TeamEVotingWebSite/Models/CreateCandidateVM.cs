using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamEVotingWebSite.Models
{
    public class CreateCandidateVM
    {
        public IEnumerable<SelectListItem> regions { get; set; }
        public IEnumerable<SelectListItem> factions { get; set; }


        public int Candidate_Id { get; set; }
        public string Candidate_FirstName { get; set; }
        public int Candidate_Age { get; set; }
        public string Candidate_LastName { get; set; }
        public Nullable<int> NumberOfVotes { get; set; }
        public int Region_Id { get; set; }
        public string Region_Name { get; set; }

        public int Faction_Id { get; set; }
        public string Faction_Name { get; set; }

       

    }
}