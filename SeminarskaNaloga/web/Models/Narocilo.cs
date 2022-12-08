using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Narocilo
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int NarociloId { get; set; }
	public DateTime datum { get; set; }
	public int ArtikelId { get; set; }
	public float vrednost { get; set; }
	public int kolicina { get; set; }
	
	#nullable enable
	public Artikel? Artikel { get; set; }


}
