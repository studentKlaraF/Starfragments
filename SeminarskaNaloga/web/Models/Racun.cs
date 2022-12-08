using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Racun
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RacunId { get; set; }
	public DateTime datum { get; set; }
	public int kolicina { get; set; }
	public float cena { get; set; }
	public float postnina { get; set; }
	
	public int UporabnikId { get; set; }
    public int NarociloId { get; set; }

	#nullable enable
	public Uporabnik? Uporabnik { get; set; }
	public Narocilo? Narocilo { get; set; }


}
