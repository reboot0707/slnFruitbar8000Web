using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prjFruitbar8000Web.Models.ViewModels
{
    public class SongsListViewModel
    {
        [StringLength(200)]
        [Display(Name ="歌曲名稱")]
        public string SongName { get; set; }

        [StringLength(400)]
        [Display(Name = "創作者")]
        public string ArtistNameList { get; set; }

        [StringLength(200)]
        [Display(Name = "專輯名稱")]
        public string AlbumName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "發行時間")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "專輯封面")]
        public byte[] CoverPic { get; set; }
    }
}