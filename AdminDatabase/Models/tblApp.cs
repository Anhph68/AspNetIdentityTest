//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminDatabase.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblApp
    {
        public tblApp()
        {
            this.tblRoleActions = new HashSet<tblRoleAction>();
            this.tblActions = new HashSet<tblAction>();
        }
    
        public int Id { get; set; }
        public string AppName { get; set; }
        public string AppUrl { get; set; }
        public string Note { get; set; }
    
        public virtual ICollection<tblRoleAction> tblRoleActions { get; set; }
        public virtual ICollection<tblAction> tblActions { get; set; }
    }
}