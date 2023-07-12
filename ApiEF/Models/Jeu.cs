using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEF.Models
{
    public class Jeu
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Annee { get; set; }
        [Range(0, 5, ErrorMessage = "La note doit être comprise entre 0 et 5.")]
        public int Note { get; set; }
        public string Descriptif { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

}
