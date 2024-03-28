using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public Guid? CategoryGroupId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImg {  get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        [ForeignKey("CategoryGroupId")]
        public CategoryGroup? CategoryGroups { get; set; }
        //
        public ICollection<Product>? Products { get; set; }
    }
}
