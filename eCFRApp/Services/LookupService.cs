using eCFRAnalyis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Services
{
	public class LookupService : ILookupService
	{
		private string agencyfilePath = "FileStorage/agencies.json";
		private string correctionsfilePath = "FileStorage/corrections.json";
		private string titlesfilePath = "FileStorage/titles.json";
		/*
		 * Store and retrival task is usually performed via db.
		 */
		public async Task<AgencyData> SaveAgencyJsonToFileAsync(string jsonResponse)
		{
			try
			{
				string jsonString = jsonResponse;
				string relativeFolderPath = Path.Combine(Environment.CurrentDirectory, agencyfilePath);

				await File.WriteAllTextAsync(agencyfilePath, jsonString);
				var agencies = JsonConvert.DeserializeObject<AgencyData>(jsonResponse);
				return agencies ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
		}

		public async Task<eCFRCorrectionData> SaveeCFRCorrectionsJsonToFileAsync(string jsonResponse)
		{
			try
			{
				string jsonString = jsonResponse;
				string relativeFolderPath = Path.Combine(Environment.CurrentDirectory, correctionsfilePath);

				await File.WriteAllTextAsync(correctionsfilePath, jsonString);
				var corrections = JsonConvert.DeserializeObject<eCFRCorrectionData>(jsonResponse);
				return corrections ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
		}

		/*
		 * Store and retrival task is usually performed via db.
		 */
		public async Task<TitleData> SaveTitlesJsonToFileAsync(string jsonResponse)
		{
			try
			{
				string jsonString = jsonResponse;
				string relativeFolderPath = Path.Combine(Environment.CurrentDirectory, titlesfilePath);

				await File.WriteAllTextAsync(titlesfilePath, jsonString);
				var titles = JsonConvert.DeserializeObject<TitleData>(jsonResponse);
				return titles ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
		}

		public async Task<List<string>> GetAllAgencySlugs()
		{
			//Assuming Agency data is saved and avaialable due to constraints.
			try
			{
				var filePath = Path.Combine(Environment.CurrentDirectory, agencyfilePath);
				List<string> slugNames = null;
				if (File.Exists(filePath))
				{
					string jsonString = await File.ReadAllTextAsync(filePath);
					var agencyData = JsonConvert.DeserializeObject<AgencyData>(jsonString);
					slugNames = agencyData.Agencies != null ? agencyData.Agencies.Select(x => x.Slug).ToList() : null;
				}

				return slugNames ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
			
		}

		public async Task<string> GetAgencySlug(string name)
		{
			//Assuming Agency data is saved and avaialable due to constraints.
			try
			{
				var filePath = Path.Combine(Environment.CurrentDirectory, agencyfilePath);
				Agency agency = null;
				if (File.Exists(filePath))
				{
					string jsonString = await File.ReadAllTextAsync(filePath);
					var agencyData = JsonConvert.DeserializeObject<AgencyData>(jsonString);
					agency = agencyData.Agencies.Where(x => x.Name == name).FirstOrDefault();
				}

				return agency.Slug ?? string.Empty;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
		}

		public async Task<List<Agency>> GetAllAgencies()
		{
			//Assuming Agency data is saved and avaialable due to constraints.
			try
			{
				var filePath = Path.Combine(Environment.CurrentDirectory, agencyfilePath);
				List<Agency> agencies = null;
				if (File.Exists(filePath))
				{
					string jsonString = await File.ReadAllTextAsync(filePath);
					var agencyData = JsonConvert.DeserializeObject<AgencyData>(jsonString);
					agencies = agencyData.Agencies != null ? agencyData.Agencies.ToList() : null;
				}

				return agencies ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
			
		}

        public async Task<Agency> GetAgency(string name)
        {
            //Assuming Agency data is saved and avaialable due to constraints.
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, agencyfilePath);
                Agency agency = null;
                if (File.Exists(filePath))
                {
                    string jsonString = await File.ReadAllTextAsync(filePath);
                    var agencyData = JsonConvert.DeserializeObject<AgencyData>(jsonString);
                    agency = agencyData.Agencies.Where(x => x.Name == name).FirstOrDefault();
                }

                return agency ?? null;
            }
            catch (Exception ex)
            {
                //usually you would log exceptions
                Trace.Write(ex);
                return null;
            }
        }


        public async Task<List<Title>> GetAllTitlesAsync()
		{
			try
			{
				string filePath = Path.Combine(Environment.CurrentDirectory, titlesfilePath);
				List<Title> titles = null;
				if (File.Exists(filePath))
				{
					string jsonString = await File.ReadAllTextAsync(filePath);
					var titleData = JsonConvert.DeserializeObject<TitleData>(jsonString);
					titles = titleData.Titles != null ? titleData.Titles.ToList() : null;
				}

				return titles ?? null;
			}
			catch (Exception ex)
			{
				//usually you would log exceptions
				Trace.Write(ex);
				return null;
			}
		}

        public async Task<List<eCFR_Correction>> GetAllCorrectionsAsync()
        {
            try
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, correctionsfilePath);
                List<eCFR_Correction> corrections = null;
                if (File.Exists(filePath))
                {
                    string jsonString = await File.ReadAllTextAsync(filePath);
                    var eCFRCorrectionData = JsonConvert.DeserializeObject<eCFRCorrectionData>(jsonString);
                    corrections = eCFRCorrectionData.eCFR_Corrections != null ? eCFRCorrectionData.eCFR_Corrections.ToList() : null;
                }

                return corrections ?? null;
            }
            catch (Exception ex)
            {
                //usually you would log exceptions
                Trace.Write(ex);
                return null;
            }
        }

    }
}
