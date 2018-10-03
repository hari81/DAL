namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dealership
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dealership()
        {
            CUSTOMERs = new HashSet<CUSTOMER>();
            UserAccessMaps = new HashSet<UserAccessMaps>();
        }
        [Key]
        public int DealershipId { get; set; }

        public string Name { get; set; }
        public long Owner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessMaps> UserAccessMaps { get; set; }
        public virtual ICollection<DEALER_CUSTOMER_RELATION> DealerCustomers { get; set; }
        public virtual ICollection<DEALER_JOBSITE_RELATION> DealerJobsites { get; set; }
        public virtual ICollection<USER_SUPPORTTEAM_RELATION> Users { get; set; }
        public virtual ICollection<DEALERGROUP_DEALER_RELATION> DealerGroups { get; set; }
        public virtual ICollection<DealershipQuoteReports> DealerQuoteReports { get; set; }
    }
}
