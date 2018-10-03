namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserInvitationAccessToCustomers
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public long customerId { get; set; }
        [ForeignKey("UserInvitation")]
        public long invitationId { get; set; }

        public virtual CUSTOMER Customer { get; set; }
        public virtual UserInvitations UserInvitation { get; set; }
    }
}
