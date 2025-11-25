using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class AgencyData
	{
		public AgencyData()
		{
			Agencies = new List<Agency>();
		}

		
		public List<Agency> Agencies { get; set; }
	}
}
