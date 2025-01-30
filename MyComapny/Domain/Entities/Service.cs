using MyComapny.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyComapny.Domain.Entities
{
    public class Service :EntityBase
    {
        [Display(Name = "Select the category to which the product belongs")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }


        [Display(Name ="Short discription")]
        [MaxLength(3_000)]
        public string? DescriptionShort { get; set; }

        [Display(Name ="Description")]
        [MaxLength(100_000)]
        public string? Description { get; set; }

        [Display(Name = "Title page")]
        [MaxLength(300)]
        public string? Photo {  get; set; }

        [Display(Name ="Type product")]
        public ServiceTypeEnum TypeEnum { get; set; }
    }
}
