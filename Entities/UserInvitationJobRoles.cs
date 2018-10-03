namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserInvitationJobRoles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("JobRole")]
        public int jobRoleId { get; set; }
        [ForeignKey("UserInvitation")]
        public long invitationId { get; set; }

        public virtual USER_GROUP JobRole { get; set; }
        public virtual UserInvitations UserInvitation { get; set; }
    }
}
