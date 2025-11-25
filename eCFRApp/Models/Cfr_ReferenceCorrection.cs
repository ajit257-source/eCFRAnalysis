using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class Cfr_ReferenceCorrection
	{
		public Cfr_ReferenceCorrection()
		{
			
		}

		[JsonProperty("cfr_reference")]
		public string CfrReference { get; set; }

		[JsonProperty("hierarchy")]
		public Hierarchy Hierarchy { get; set; }
	}
}
