using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    /// <summary>
    /// consult_application:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Consult_ApplicationMdl
    {
        public Consult_ApplicationMdl()
        { }
        
        #region Model
		private string _guid;
		private string _user_guid;
		private string _user_name;
		private int _status;
		private string _patient_guid;
		private string _project_guid;
		private string _project_name;
		private int? _location_type;
		private string _purpose;
		private string _purpose_t;
		private string _local_hospital;
		private string _local_hospital_t;
		private string _preliminary_conclusions;
		private string _preliminary_conclusions_t;
		private string _final_conclusion;
		private string _final_conclusion_t;
		private DateTime? _created_dt;
		private DateTime? _submitted_dt;
		private DateTime? _accepted_dt;
		private DateTime? _approved_dt;
		private DateTime? _concluded_dt;
		private DateTime? _rejected_dt;
		private DateTime? _completed_dt;
		private string _approver_guid;
		private string _approver_name;
		private string _contract_content;
		private decimal? _amount_payable;
		private decimal? _amount_receivable;
		private DateTime? _paid_dt;
		private decimal? _amount_payable2;
		private decimal? _amount_receivable2;
		private DateTime? _paid_dt2;
		private string _service_comments_for_user;
		private string _service_comments_for_consultant;
		private string _service_comments_for_consultant_t;
		private string _specified_notes;
		private int? _number_of_hospitals;
		private string _location_guid;
		private string _location_name;
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
		public string user_guid
		{
			set{ _user_guid=value;}
			get{return _user_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
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
		public string project_guid
		{
			set{ _project_guid=value;}
			get{return _project_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string project_name
		{
			set{ _project_name=value;}
			get{return _project_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? location_type
		{
			set{ _location_type=value;}
			get{return _location_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string purpose
		{
			set{ _purpose=value;}
			get{return _purpose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string purpose_t
		{
			set{ _purpose_t=value;}
			get{return _purpose_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string local_hospital
		{
			set{ _local_hospital=value;}
			get{return _local_hospital;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string local_hospital_t
		{
			set{ _local_hospital_t=value;}
			get{return _local_hospital_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string preliminary_conclusions
		{
			set{ _preliminary_conclusions=value;}
			get{return _preliminary_conclusions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string preliminary_conclusions_t
		{
			set{ _preliminary_conclusions_t=value;}
			get{return _preliminary_conclusions_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string final_conclusion
		{
			set{ _final_conclusion=value;}
			get{return _final_conclusion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string final_conclusion_t
		{
			set{ _final_conclusion_t=value;}
			get{return _final_conclusion_t;}
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
		public DateTime? submitted_dt
		{
			set{ _submitted_dt=value;}
			get{return _submitted_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? accepted_dt
		{
			set{ _accepted_dt=value;}
			get{return _accepted_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? approved_dt
		{
			set{ _approved_dt=value;}
			get{return _approved_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? concluded_dt
		{
			set{ _concluded_dt=value;}
			get{return _concluded_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? rejected_dt
		{
			set{ _rejected_dt=value;}
			get{return _rejected_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? completed_dt
		{
			set{ _completed_dt=value;}
			get{return _completed_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string approver_guid
		{
			set{ _approver_guid=value;}
			get{return _approver_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string approver_name
		{
			set{ _approver_name=value;}
			get{return _approver_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contract_content
		{
			set{ _contract_content=value;}
			get{return _contract_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? amount_payable
		{
			set{ _amount_payable=value;}
			get{return _amount_payable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? amount_receivable
		{
			set{ _amount_receivable=value;}
			get{return _amount_receivable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? paid_dt
		{
			set{ _paid_dt=value;}
			get{return _paid_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? amount_payable2
		{
			set{ _amount_payable2=value;}
			get{return _amount_payable2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? amount_receivable2
		{
			set{ _amount_receivable2=value;}
			get{return _amount_receivable2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? paid_dt2
		{
			set{ _paid_dt2=value;}
			get{return _paid_dt2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string service_comments_for_user
		{
			set{ _service_comments_for_user=value;}
			get{return _service_comments_for_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string service_comments_for_consultant
		{
			set{ _service_comments_for_consultant=value;}
			get{return _service_comments_for_consultant;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string service_comments_for_consultant_t
		{
			set{ _service_comments_for_consultant_t=value;}
			get{return _service_comments_for_consultant_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specified_notes
		{
			set{ _specified_notes=value;}
			get{return _specified_notes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? number_of_hospitals
		{
			set{ _number_of_hospitals=value;}
			get{return _number_of_hospitals;}
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
		#endregion Model

    }
}
