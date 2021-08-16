using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBulbTunes.EFDataService.Models
{
    public class Favourite
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid SelectedSongId { get; set; }

        [Required]
        public virtual Song SelectedSong { get; set; }


        //Navigation Properties
        [Required]
        public Guid AddedByUserId { get; set; }

        [Required]
        public virtual User AddedBy { get; set; }
    }
}
