//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamEVotingWebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSet
    {
        public int User_Id { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public int Candidate_Id { get; set; }
    
        public virtual CandidateSet CandidateSet { get; set; }
    }
}