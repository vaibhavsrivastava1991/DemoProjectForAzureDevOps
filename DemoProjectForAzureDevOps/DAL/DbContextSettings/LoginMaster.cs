//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DbContextSettings
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginMaster
    {
        public System.Guid LoginMasterId { get; set; }
        public string UserName { get; set; }
        public string LoginPassword { get; set; }
        public Nullable<System.Guid> UserProfileId { get; set; }
        public virtual UserProfileMaster UserProfileMaster { get; set; }
    }
}
