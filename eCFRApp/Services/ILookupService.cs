using eCFRAnalyis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Services
{
	public interface ILookupService
	{
		Task<AgencyData> SaveAgencyJsonToFileAsync(string jsonString);
		Task<eCFRCorrectionData> SaveeCFRCorrectionsJsonToFileAsync(string jsonResponse);
		Task<TitleData> SaveTitlesJsonToFileAsync(string jsonResponse);
		Task<List<string>> GetAllAgencySlugs();
		Task<string> GetAgencySlug(string name);
		Task<List<Agency>> GetAllAgencies();
        Task<Agency> GetAgency(string name);

        Task<List<Title>> GetAllTitlesAsync();

        Task<List<eCFR_Correction>> GetAllCorrectionsAsync();

    }
}
