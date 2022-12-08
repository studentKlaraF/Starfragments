using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Artikel
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ArtikelId { get; set; }
	public string img { get; set; }
	public string naziv { get; set; }
	public double cena { get; set; }
	public string opis { get; set; }
	public int zaloga { get; set; }

}
