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
    public class ApplicationMdl
    {
        public ApplicationMdl()
        { }
        #region Model
        private string _guid;
        private string _user_guid;
        private string _user_name;
        private int _status;
        private string _project_guid;
        private string _project_name;
        private string _location_guid;
        private string _location_name;
        private string _hospital_guid;
        private string _hospital_name;
        private string _doctor_guid;
        private string _doctor_name;
        private string _purpose;
        private string _purpose_t;
        private string _local_hospital;
        private string _local_hospital_t;
        private string _conclusion;
        private string _conclusion_t;
        private string _conclusion_doctor_guid;
        private string _conclusion_doctor_name;
        private DateTime? _created_dt;
        private DateTime? _submitted_dt;
        private DateTime? _approved_dt;
        private DateTime? _delivered_dt;
        private DateTime? _concluded_dt;
        private DateTime? _rejected_dt;
        private DateTime? _completed_dt;
        private string _approver_guid;
        private string _approver_name;
        private string _deliver_guid;
        private string _deliver_name;
        private string _contract_content;
        private decimal? _amount_payable;
        private decimal? _amount_receivable;
        private DateTime? _paid_dt;
        /// <summary>
        /// 
        /// </summary>
        public string guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_guid
        {
            set { _user_guid = value; }
            get { return _user_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string project_guid
        {
            set { _project_guid = value; }
            get { return _project_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string project_name
        {
            set { _project_name = value; }
            get { return _project_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string location_guid
        {
            set { _location_guid = value; }
            get { return _location_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string location_name
        {
            set { _location_name = value; }
            get { return _location_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital_guid
        {
            set { _hospital_guid = value; }
            get { return _hospital_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital_name
        {
            set { _hospital_name = value; }
            get { return _hospital_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doctor_guid
        {
            set { _doctor_guid = value; }
            get { return _doctor_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doctor_name
        {
            set { _doctor_name = value; }
            get { return _doctor_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string purpose
        {
            set { _purpose = value; }
            get { return _purpose; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string purpose_t
        {
            set { _purpose_t = value; }
            get { return _purpose_t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string local_hospital
        {
            set { _local_hospital = value; }
            get { return _local_hospital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string local_hospital_t
        {
            set { _local_hospital_t = value; }
            get { return _local_hospital_t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string conclusion
        {
            set { _conclusion = value; }
            get { return _conclusion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string conclusion_t
        {
            set { _conclusion_t = value; }
            get { return _conclusion_t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string conclusion_doctor_guid
        {
            set { _conclusion_doctor_guid = value; }
            get { return _conclusion_doctor_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string conclusion_doctor_name
        {
            set { _conclusion_doctor_name = value; }
            get { return _conclusion_doctor_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? created_dt
        {
            set { _created_dt = value; }
            get { return _created_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? submitted_dt
        {
            set { _submitted_dt = value; }
            get { return _submitted_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? approved_dt
        {
            set { _approved_dt = value; }
            get { return _approved_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? delivered_dt
        {
            set { _delivered_dt = value; }
            get { return _delivered_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? concluded_dt
        {
            set { _concluded_dt = value; }
            get { return _concluded_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? rejected_dt
        {
            set { _rejected_dt = value; }
            get { return _rejected_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? completed_dt
        {
            set { _completed_dt = value; }
            get { return _completed_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string approver_guid
        {
            set { _approver_guid = value; }
            get { return _approver_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string approver_name
        {
            set { _approver_name = value; }
            get { return _approver_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deliver_guid
        {
            set { _deliver_guid = value; }
            get { return _deliver_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deliver_name
        {
            set { _deliver_name = value; }
            get { return _deliver_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contract_content
        {
            set { _contract_content = value; }
            get { return _contract_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? amount_payable
        {
            set { _amount_payable = value; }
            get { return _amount_payable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? amount_receivable
        {
            set { _amount_receivable = value; }
            get { return _amount_receivable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? paid_dt
        {
            set { _paid_dt = value; }
            get { return _paid_dt; }
        }
        #endregion Model

    }
}
