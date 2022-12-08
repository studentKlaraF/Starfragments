using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarskaNaloga.Models;
using Microsoft.AspNetCore.Authorization;
public class ZgodovinaNarocanja
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
	
	public int ZgodovinaNarocanjaId { get; set; }
	public int UporabnikId { get; set; }
    public int NarociloId { get; set; }

	#nullable enable
	public Uporabnik? Uporabnik { get; set; }
	public Narocilo? Narocilo { get; set; }


}
