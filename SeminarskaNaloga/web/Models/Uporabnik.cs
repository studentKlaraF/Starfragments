using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Uporabnik : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int UporabnikId { get; set; }
	public string ime { get; set; }
	public string priimek { get; set; }
	public string naslov { get; set; }
	public string posta { get; set; }
	public int stPoste { get; set; }
	public int telefon { get; set; }

	public bool admin { get; set; }
    
}
