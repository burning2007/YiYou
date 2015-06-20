using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class V_Sys_UserMdl
    {
        public V_Sys_UserMdl()
		{
            
        }

		#region Model

		private string _guid;
		private string _login_name;
		private string _name;
		private string _password;
		private int _role;
		private string _email;
		private byte[] _avatar;
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
		public string login_name
		{
			set{ _login_name=value;}
			get{return _login_name;}
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
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int role
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] avatar
		{
			set{ _avatar=value;}
			get{return _avatar;}
		}

		#endregion Model
    }
}
