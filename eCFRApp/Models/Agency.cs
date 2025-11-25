using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class Agency
	{
		public Agency()
		{
			CFRReferences = new List<Cfr_References>();
		}

		public string Name { get; set; }
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public string Slug { get; set; }
		[JsonProperty("cfr_references")]
		public List<Cfr_References> CFRReferences { get; set; }
	}
}
