using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class Title
	{
		public int Number { get; set; }
		public string Name { get; set; }
		[JsonProperty("latest_amended_on")]
		public string LatestAmendedOn { get; set; }
		[JsonProperty("latest_issue_date")]
		public string LatestIssueDate { get; set; }
		[JsonProperty("up_to_date_as_of")]
		public string UpToDateAsOf { get; set; }
	}
}
