using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class consult_application_accessoryMdl
    {
        public consult_application_accessoryMdl()
        { }
        #region Model
        private string _guid;
        private string _consult_application_guid;
        private int _type;
        private byte[] _content;
        private byte[] _thumbnail;
        private string _comments;
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
        public string consult_application_guid
        {
            set { _consult_application_guid = value; }
            get { return _consult_application_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] thumbnail
        {
            set { _thumbnail = value; }
            get { return _thumbnail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comments
        {
            set { _comments = value; }
            get { return _comments; }
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
