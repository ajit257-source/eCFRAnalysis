using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCFRAnalyis.Utility;
using Newtonsoft.Json;
using eCFRAnalyis.Models;
using eCFRAnalyis.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCFRAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
		private readonly string baseUrl = "https://www.ecfr.gov/";
		private readonly IAnalysisService _analysisService;
		private readonly ILookupService _lookService;

		public AnalysisController(IAnalysisService analysisService, ILookupService lookService)
		{
			_analysisService = analysisService;
			_lookService = lookService;
		}

		// GET: This should be done by supplying agency as input
		[HttpGet("GetWordCountPerAgency")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWordCountPerAgencyAsync([FromQuery, BindRequired] string term)
		{
			//Assuming Agency data is saved and avaialable due to constraints.

			List<string> agencies = await _lookService.GetAllAgencySlugs();
			List<string> results = new List<string>();

			var client = ApiClient.GetApiClient(baseUrl);
			string agencySlugParam = string.Empty;
			foreach (string s in agencies)
			{
				agencySlugParam = "&agency_slugs[]=" + s;
				string requestUri = $"{baseUrl}api/search/v1/count?query={term}{agencySlugParam}";
				HttpResponseMessage response = await client.GetAsync(requestUri);

				if (response.IsSuccessStatusCode)
				{
					string jsonResponse = await response.Content.ReadAsStringAsync();
					results.Add(jsonResponse);
				}
			}

			return (results == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(results);

		}

		// GET: Supplying agency name as input
		[HttpGet("GetWordCountForAgency")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWordCountForAgencyAsync([FromQuery, BindRequired]string term, [FromQuery, BindRequired]string agencyname)
		{
			//Assuming Agency data is saved and avaialable due to constraints.

			string agencySlug = await _lookService.GetAgencySlug(agencyname);
			List<string> results = new List<string>();

			var client = ApiClient.GetApiClient(baseUrl);

			string requestUri = $"{baseUrl}api/search/v1/count?query={term}&agency_slugs[]={agencySlug}";
			HttpResponseMessage response = await client.GetAsync(requestUri);

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				results.Add(jsonResponse);
			}

			return (results == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(results);
		}

        // GET: GetCheckSumForAgency
        [HttpGet("GetCheckSumForAgency")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCheckSumForAgency([FromQuery, BindRequired]string agencyname)
        {
            //Assuming Agency data is saved and avaialable due to constraints.

            Agency agency = await _lookService.GetAgency(agencyname);
            List<eCFR_Correction> corrections = await _lookService.GetAllCorrectionsAsync();
            List<eCFR_Correction> results = new List<eCFR_Correction>();

            var cfrReferences = agency.CFRReferences.ToList();
            foreach (Cfr_References cfr in cfrReferences)
            {
                var titleCorrections = corrections.ToList().Where(x => x.Title == cfr.Title).ToList();
                results.AddRange(titleCorrections);
            }

            return (results == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(results);
        }


        // GET: Custom Metric : Which  titles had max changes
        [HttpGet("GetTitlesWithMaxChanges")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTitlesWithMaxChanges()
        {
            //Assuming Agency data is saved and avaialable due to constraints.

            List<Agency> agencies = await _lookService.GetAllAgencies();
            List<eCFR_Correction> corrections = await _lookService.GetAllCorrectionsAsync();

            var groups = corrections.OrderBy(x => x.Title)
                   .GroupBy(x => x.Title)
                   .Where(g => g.Count() > 1)
                   .Select(g => new {
                       TitleNumber = g.Key,
                       TotalCountOfChanges = g.Count()
                   })
                   .ToList().OrderByDescending(y => y.TotalCountOfChanges);
            
            return (groups == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(groups);
        }
    }
}
