using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public partial class UserInvitations
    {
        public UserInvitations()
        {
            unique_id = Guid.NewGuid();
        }

        [Key]
        public long invitation_auto { get; set; }

        public int team_type { get; set; }

        public long team_id { get; set; }

        public string email { get; set; }
        public string name { get; set; }
        public string username { get; set; }

        public int access_level { get; set; }

        public Guid unique_id { get; set; }

        public DateTime invitation_sent { get; set; }

        public bool disable { get; set; }
        public string SenderEmail { get; set; }
        public string SenderAspUserId { get; set; }
        public bool InvitationAccepted  { get; set; } = false;

        public bool EnableUndercarriage { get; set; }
        public bool EnableGET { get; set; }
    }
}