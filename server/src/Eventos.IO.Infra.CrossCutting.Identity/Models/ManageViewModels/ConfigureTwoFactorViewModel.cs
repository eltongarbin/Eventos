using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Eventos.IO.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}
