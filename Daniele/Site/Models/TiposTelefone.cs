using System.ComponentModel;

namespace Site.Models
{
    public enum TiposTelefone
    {
        [DefaultValue("C"), Description("Celular")]
        Celular,

        [DefaultValue("R"), Description("Residencial")]
        Residencial,

        [DefaultValue("T"), Description("Trabalho")]
        Trabalho,

        [DefaultValue("W"), Description("Whatsapp")]
        Whastsapp
    }
}