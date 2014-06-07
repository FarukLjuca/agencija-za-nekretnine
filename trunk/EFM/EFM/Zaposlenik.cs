using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace EFM
{
    public class Zaposlenik : Osoba
    {
    
    private decimal plata;
	private string jmbg;
    
    /// <summary>
    /// Kreira novi objekat tipa Zaposlenik
    /// </summary>
    /// <param name="Ime">Ime zaposlenika</param>
    /// <param name="Prezime">Prezime zaposlenika</param>
    /// <param name="AdresaStanovanja">Adresa zaposlenika</param>
    /// <param name="BrojTelefona">Broj telefona od zaposlenika</param>
    /// <param name="DatumRodjenja">Datum rodjenja zaposlenika</param>
	/// <param name="DatumUposlenja">Datum uposlenja zaposlenika</param>
	/// <param name="JMBG">Maticni broj</param>
    /// <param name="BrojLicneKarte">Broj licne karte od zaposlenika</param>
	/// <param name="UserName">Username zaposlenog</param>
	/// <param name="Password">Password zaposlenog</param>
    /// <param name="Plata">Plata od zaposlenika</param>
	/// <param name="Slika">Slika zaposlenog</param>
    /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada su podaci netacni</exception>
    public Zaposlenik(string Ime, string Prezime, string AdresaStanovanja, 
		string BrojTelefona, DateTime DatumRodjenja, DateTime DatumUposlenja, string BrojLicneKarte,
		string UserName, String PassWord, decimal Plata, Image Slika)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {
            this.Plata = Plata;
			if (string.IsNullOrWhiteSpace (UserName) || string.IsNullOrWhiteSpace (PassWord.ToString ()))
				throw new Exc.ArgumentException ("Username i password ne smiju biti prazni!");
			this.UserName = UserName;
			this.PassWord = PassWord;
			this.DatumUposlenja = DatumUposlenja;
			this.Slika = Slika;
        }
	public string JMBG
	{
		get { return jmbg; }
		set 
			{
				if (value.Length != 13)
					throw new Exc.ArgumentException ("JMBG mora biti u ispravnom formatu. 13 znakova tačno!");
				jmbg = value;
			}
	}
	public DateTime DatumUposlenja { get; set; }
	public Image Slika { get; set; }
	public virtual string TIP { get; set; }
    /// <summary>
    /// Plata za zaposlenika
    /// </summary>
    public Decimal Plata
    { 
        get { return plata;} 
        set { if (value < 0) throw new Exception("PLata ne moze biti negativna!"); plata = value; } 
    }
	public string UserName { get; set; }
	public  string PassWord { get; set; }
    /// <summary>
    /// Konstrukor bez parametara, namjenjen za inicijaliziranje zaposlenika
    /// </summary>
    public Zaposlenik ()
        {

        }
    }
}

