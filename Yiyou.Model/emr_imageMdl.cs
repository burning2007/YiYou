using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class emr_imageMdl
    {
        public emr_imageMdl()
        { }
        #region Model
        private string _guid;
        private string _emr_guid;
        private int _img_type;
        private byte[] _img_content;
        private byte[] _thumbnail;
        private string _img_url;
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
        public string emr_guid
        {
            set { _emr_guid = value; }
            get { return _emr_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int img_type
        {
            set { _img_type = value; }
            get { return _img_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] img_content
        {
            set { _img_content = value; }
            get { return _img_content; }
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
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        #endregion Model
    }
}
