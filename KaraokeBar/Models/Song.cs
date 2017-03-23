using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeBar.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string SongName { get; set; }
        public string SongArtist { get; set; }
        public virtual ICollection<Tab> SongTabs { get; set; }
    }
}