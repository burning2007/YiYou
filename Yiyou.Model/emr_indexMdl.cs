using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class emr_indexMdl
    {
        public emr_indexMdl()
        { }
        #region Model
        private string _guid;
        private string _patient_guid;
        private string _type_guid;
        private string _type_name;
        private int _img_count;
        private string _content;
        private string _content_t;
        private string _hospital;
        private string _hospital_t;
        private DateTime? _created_dt;
        private DateTime? _modified_dt;
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
        public string patient_guid
        {
            set { _patient_guid = value; }
            get { return _patient_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type_guid
        {
            set { _type_guid = value; }
            get { return _type_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type_name
        {
            set { _type_name = value; }
            get { return _type_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int img_count
        {
            set { _img_count = value; }
            get { return _img_count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content_t
        {
            set { _content_t = value; }
            get { return _content_t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital
        {
            set { _hospital = value; }
            get { return _hospital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital_t
        {
            set { _hospital_t = value; }
            get { return _hospital_t; }
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
        public DateTime? modified_dt
        {
            set { _modified_dt = value; }
            get { return _modified_dt; }
        }
        #endregion Model
    }
}
