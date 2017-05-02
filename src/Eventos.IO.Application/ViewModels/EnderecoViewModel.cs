using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }

        public SelectList Estados()
        {
            return new SelectList(EstadoViewModel.ListarEstados(), "UF", "Nome");
        }

        public override string ToString()
        {
            return string.Concat(Logradouro, ", ", Numero, " - ", Bairro, ", ", Cidade, " - ", Estado);
        }
    }
}
