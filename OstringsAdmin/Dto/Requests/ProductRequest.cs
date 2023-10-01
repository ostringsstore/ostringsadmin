using System.ComponentModel.DataAnnotations;
namespace OstringsAdmin.Dto.Requests
{
    public class ProductRequest
    {
        private const string obligatoryField = "Campo obligatorio";

        [Required(ErrorMessage = obligatoryField)] 
        public string Name { get; set; }

        [Required(ErrorMessage = obligatoryField)] 
        public string Description { get; set; }

        [Required(ErrorMessage = obligatoryField)] 
        [Range(0, double.MaxValue, ErrorMessage = "El precio de distribución no puede ser un numero negativo")]
        public double? DistributionPrice { get; set; }

        [Required(ErrorMessage = obligatoryField)] 
        [Range(0, double.MaxValue, ErrorMessage = "El precio de al publico no puede ser un numero negativo")]
        public double? RetailPrice { get; set; }

        [Required(ErrorMessage = obligatoryField)]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser un numero negativo")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = obligatoryField)]
        public string Reference { get; set; }

        [Required(ErrorMessage = obligatoryField)]
        public Guid? CateogryId { get; set; }
    }
}
