using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase2024.Models
{

    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public  int Id  { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o local!")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o dia e horário inicial!")]
        [Display(Name =" Dia e Horário")]
        public DateTime HorarioInicial { get; set;}

        [Required(ErrorMessage = "Obrigatório informar o patrocinador")]
        public int Patrocinador { get; set; }

    }
}
