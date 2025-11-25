using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCFRAnalyis.Models
{
	public class TitleData
	{
		public TitleData()
		{
			Titles = new List<Title>();
		}
		public List<Title> Titles { get; set; }
	}
}
