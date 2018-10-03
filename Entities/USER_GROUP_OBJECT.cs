namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_GROUP_OBJECT
    {
        public int group_auto { get; set; }

        public int object_auto { get; set; }

        public DateTime? created_date { get; set; }

        public int? created_user_auto { get; set; }

        public int Id { get; set; }

        public virtual USER_GROUP USER_GROUP { get; set; }
    }
}
