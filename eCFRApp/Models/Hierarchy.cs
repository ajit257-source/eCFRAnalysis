using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class Hierarchy
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("subtitle")]
		public string Subtitle { get; set; }
		[JsonProperty("part")]
		public string Part { get; set; }
		[JsonProperty("subpart")]
		public string SubPart { get; set; }
		[JsonProperty("section")]
		public string Section { get; set; }
	}
}
