using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class Consult_Application_ConsultantMdl
    {
        public Consult_Application_ConsultantMdl()
		{}

		#region Model
		private string _guid;
		private string _consult_application_guid;
		private string _location_guid;
		private string _location_name;
		private string _hospital_guid;
		private string _hospital_name;
		private string _doctor_guid;
		private string _doctor_name;
		private string _conclusion;
		private string _conclusion_t;
		private DateTime? _concluded_dt;
		/// <summary>
		/// 
		/// </summary>
		public string guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string consult_application_guid
		{
			set{ _consult_application_guid=value;}
			get{return _consult_application_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string location_guid
		{
			set{ _location_guid=value;}
			get{return _location_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string location_name
		{
			set{ _location_name=value;}
			get{return _location_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospital_guid
		{
			set{ _hospital_guid=value;}
			get{return _hospital_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospital_name
		{
			set{ _hospital_name=value;}
			get{return _hospital_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string doctor_guid
		{
			set{ _doctor_guid=value;}
			get{return _doctor_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string doctor_name
		{
			set{ _doctor_name=value;}
			get{return _doctor_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string conclusion
		{
			set{ _conclusion=value;}
			get{return _conclusion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string conclusion_t
		{
			set{ _conclusion_t=value;}
			get{return _conclusion_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? concluded_dt
		{
			set{ _concluded_dt=value;}
			get{return _concluded_dt;}
		}
		#endregion Model
    }
}
