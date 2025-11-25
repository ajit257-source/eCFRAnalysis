using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class eCFRCorrectionData
	{
		public eCFRCorrectionData()
		{
			eCFR_Corrections = new List<eCFR_Correction>();
		}


		public List<eCFR_Correction> eCFR_Corrections { get; set; }
	}
}
