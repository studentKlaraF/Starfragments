using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarskaNaloga.Models;
public class ZgodovinaNarocanja
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
	
	public int IDstranke { get; set; }
    public int IDnarocila { get; set; }
	public Stranka Stranka { get; set; }
	public Narocilo Narocilo { get; set; }


}
