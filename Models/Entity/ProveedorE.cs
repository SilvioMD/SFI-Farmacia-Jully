using System.ComponentModel.DataAnnotations;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class ProveedorE
    {

        public int IdProveedor { get; set; }
        [StringLength(150)]
        public string NombreProveedor { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }


    }
}