//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Voat.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int ID { get; set; }
        public string CorrelationID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int Type { get; set; }
        public string Sender { get; set; }
        public int SenderType { get; set; }
        public string Recipient { get; set; }
        public int RecipientType { get; set; }
        public string Subverse { get; set; }
        public Nullable<int> SubmissionID { get; set; }
        public Nullable<int> CommentID { get; set; }
        public bool IsAnonymized { get; set; }
        public Nullable<System.DateTime> ReadDate { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FormattedContent { get; set; }
        public string CreatedBy { get; set; }
    }
}