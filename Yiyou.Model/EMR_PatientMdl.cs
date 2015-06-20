using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class EMR_PatientMdl
    {
        public EMR_PatientMdl()
		{}
		#region Model
		private string _patient_guid;
		private string _user_guid;
		private string _name;
		private int _gender;
		private DateTime? _birthday;
		private string _diagnosis;
		private string _diagnosis_t;
		private DateTime? _created_dt;
		private DateTime? _modified_dt;
		/// <summary>
		/// 
		/// </summary>
		public string patient_guid
		{
			set{ _patient_guid=value;}
			get{return _patient_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_guid
		{
			set{ _user_guid=value;}
			get{return _user_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string diagnosis
		{
			set{ _diagnosis=value;}
			get{return _diagnosis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string diagnosis_t
		{
			set{ _diagnosis_t=value;}
			get{return _diagnosis_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? created_dt
		{
			set{ _created_dt=value;}
			get{return _created_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? modified_dt
		{
			set{ _modified_dt=value;}
			get{return _modified_dt;}
		}
		#endregion Model
    }
}
