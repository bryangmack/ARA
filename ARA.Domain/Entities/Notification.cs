//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARA.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public int NotificationID { get; set; }
        public int ThresholdID { get; set; }
        public int SectionID { get; set; }
        public System.DateTime NotifiedOn { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual Threshold Threshold { get; set; }
    }
}