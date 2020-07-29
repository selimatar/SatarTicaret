using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SatarTicaret.Models;

namespace SatarTicaret.App_Classes
{
    public class Context
    {
        private static B407eTicaretContext baglanti;

	public static B407eTicaretContext Baglanti
	{
		get
        {
            if (baglanti == null)
                baglanti = new B407eTicaretContext();
            return baglanti;
        }
		set { baglanti = value;}
	}
	
    }
}