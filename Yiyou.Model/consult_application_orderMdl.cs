using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class consult_application_orderMdl
    {
        public consult_application_orderMdl()
        { }
        #region Model
        private long _id;
        private string _consult_application_guid;
        private string _order_id;
        private int? _order_type;
        private string _order_status;
        private decimal? _amount_receivable;
        private DateTime? _created_dt;
        private DateTime? _modified_dt;
        private string _comments;
        private decimal? _amount_payable;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
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
        public string order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? order_type
        {
            set { _order_type = value; }
            get { return _order_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string order_status
        {
            set { _order_status = value; }
            get { return _order_status; }
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
        public decimal? amount_payable
        {
            set { _amount_payable = value; }
            get { return _amount_payable; }
        }
        #endregion Model
    }
}
