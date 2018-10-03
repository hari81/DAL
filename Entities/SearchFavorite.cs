using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DAL
{
    [Table("SearchFavorite")]
    public class SearchFavorite
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        [Index("IX_UserIdName", 1, IsUnique = true)]
        public long UserId { get; set; }
        [StringLength(250,MinimumLength = 3)]
        [Required]
        [Index("IX_UserIdName", 2, IsUnique = true)]
        public string Name { get; set; }
        [StringLength(20)]
        public string BackgroundColor { get; set; }
        [StringLength(20)]
        public string TextColor { get; set; }
        public virtual USER_TABLE User { get; set; }
        public virtual ICollection<SearchFavoriteItems> SearchFavoriteItems { get; set; }
    }
    [Table("SearchFavoriteItems")]
    public class SearchFavoriteItems {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SearchFavorite")]
        public int SearchFavoriteId { get; set; }
        public int ItemId { get; set; }
        public int SearchId { get; set; }
        [StringLength(100)]
        public string SearchStr { get; set; }
        public virtual SearchFavorite SearchFavorite { get; set; }
    }

    /*
 Declared Search Item Ids 
 { Id :  1,Title :  "Customer" }
 { Id :  2,Title :  "Jobsite" }
 { Id :  3,Title :  "Equipment" }
 { Id :  4,Title :  "Family" }
 { Id :  5,Title :  "Make" }
 { Id :  6,Title :  "Model" }
 { Id :  7,Title :  "System" }
 { Id :  8,Title :  "Evaluation A" }
 { Id :  9,Title :  "Evaluation B" }
 { Id :  10,Title :  "Evaluation C" }
 { Id :  11,Title :  "Evaluation X" }
*/
}