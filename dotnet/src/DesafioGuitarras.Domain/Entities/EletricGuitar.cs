using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioGuitarras.Domain.Entities
{
    public class EletricGuitar
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [StringLength(400)]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Preço (R$)")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public decimal Price { get; set; }

        [StringLength(800)]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Description { get; set; }

        [Display(Name = "Data de Inserção")]
        public DateTime InsertDate { get; set; }

        [StringLength(8000)]
        [Display(Name = "Url")]
        public string ImageUrl { get; set; }

        [StringLength(500)]
        [Display(Name = "Sku")]
        public string Sku { get => $"{Id}_{Name.ToLower().Replace(' ', '_')}"; set { } }

        public DomainValidation.Validation.ValidationResult Validation { get; set; }
    }
}
