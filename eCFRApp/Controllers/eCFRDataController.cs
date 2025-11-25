using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using eCFRAnalyis.Models;
using eCFRAnalyis.Services;
using eCFRAnalyis.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCFRAnalyis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eCFRDataController : ControllerBase
    {
		private readonly string baseUrl = "https://www.ecfr.gov/";
		private readonly IAnalysisService _analysisService;
		private readonly ILookupService _lookService;

		public eCFRDataController(IAnalysisService analysisService, ILookupService lookService)
		{
			_analysisService = analysisService;
			_lookService = lookService;
		}

		// GET: api/Analysis
		[HttpGet("GetAgencies")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgenciesAsync()
		{
			AgencyData agencies = null;
			var client = ApiClient.GetApiClient(baseUrl);

			HttpResponseMessage response = await client.GetAsync("/api/admin/v1/agencies.json");

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				agencies = await _lookService.SaveAgencyJsonToFileAsync(jsonResponse);
			}

			return (agencies == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(agencies);

		}

		// GET: api/Analysis
		[HttpGet("GetCorrections")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCorrectionsAsync()
		{
			var client = ApiClient.GetApiClient(baseUrl);
			eCFRCorrectionData corrections = null;

			HttpResponseMessage response = await client.GetAsync("/api/admin/v1/corrections.json");

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				corrections = await _lookService.SaveeCFRCorrectionsJsonToFileAsync(jsonResponse);
			}

			return (corrections == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(corrections);

		}

		// GET: api/Analysis
		[HttpGet("GetTitles")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTitlesAsync()
		{
			var client = ApiClient.GetApiClient(baseUrl);
			TitleData titles = null;

			HttpResponseMessage response = await client.GetAsync("/api/versioner/v1/titles.json");

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				titles = await _lookService.SaveTitlesJsonToFileAsync(jsonResponse);
			}

			return (titles == null) ? (IActionResult)NotFound("Data not found.") : (IActionResult)Ok(titles);

		}
	}
}
