using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class eCFR_Correction
	{
		public eCFR_Correction()
		{
			CFRReferences = new List<Cfr_ReferenceCorrection>();
		}

		[JsonProperty("id")]
		public int Id { get; set; }
		
		[JsonProperty("cfr_references")]
		public List<Cfr_ReferenceCorrection> CFRReferences { get; set; }

		[JsonProperty("corrective_action")]
		public string CorrectiveAction { get; set; }

		[JsonProperty("error_corrected")]
		public string ErroCorrected { get; set; }

		[JsonProperty("ErrorOccurred")]
		public string error_occurred { get; set; }

		[JsonProperty("fr_citation")]
		public string FrCitation { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("display_in_toc")]
		public string DisplayInToc { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("year")]
		public string Year { get; set; }

		[JsonProperty("last_modified")]
		public string LastModified { get; set; }

	}
}
