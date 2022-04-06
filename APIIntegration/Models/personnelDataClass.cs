using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIIntegration.Models
{
    public class personnelDataClass
    {
		public Nullable<int> personnelID { get; set; }
		public string lastname { get; set; }
		public string firstname { get; set; }
		public string middlename { get; set; }
		public string maidenname { get; set; }
		public string rank { get; set; }
		public string gender { get; set; }
		public string trn { get; set; }
		public string email { get; set; }
		public Nullable<int> geo_area { get; set; }
		public Nullable<int> geo_division { get; set; }
		public Nullable<int> geo_station { get; set; }
		public Nullable<int> geo_section { get; set; }
		public Nullable<int> ngeo_portfolio { get; set; }
		public Nullable<int> ngeo_branch { get; set; }
		public Nullable<int> ngeo_division { get; set; }
		public Nullable<int> ngeo_section { get; set; }
		public Nullable<System.DateTime> enlistmentDate { get; set; }
		public Nullable<short> deleted { get; set; }
		public Nullable<short> isServingMember { get; set; }
		public Nullable<System.DateTime> updateDate { get; set; }
		public Nullable<System.DateTime> terminationDate { get; set; }

	}
}