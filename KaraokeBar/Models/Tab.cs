using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeBar.Models
{
    public class Tab
    {
        public int TabID { get; set; }
        public virtual  ICollection<Drink> DrinkList { get; set; }
        public virtual ICollection<Song> SongList { get; set; }
    }
}