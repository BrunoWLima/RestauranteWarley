using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWarley.Models
{
    public class ModelPedidos
    {
        [Required(ErrorMessage = "Campo não pode estar vázio")]
        public string Pedido { get; set; }
        public List<string> ListaPedidos { get; set; }
        public List<string> ListCardapio { get; set; }
    }
}