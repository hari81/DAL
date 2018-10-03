namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMPART_PARENT_RELATION
    {
        public int Id { get; set; }

        public int? ParentCompartId { get; set; }

        public int ChildCompartId { get; set; }

        public virtual LU_COMPART ParentCompartment { get; set; }

        public virtual LU_COMPART ChildCompartment { get; set; }
    }
}
