using System;

namespace API.GiamKichSan.Models
{
	public class ResObject
	{
		private const string _validate = "00";
		public String codeError { get; set; }
		public String strError { get; set; }
		public Object obj { get; set; }
		public Object listObj { get; set; }
		public Object arrObj { get; set; }

		public ResObject()
		{
			codeError = _validate;
			//strError = "Không xử lý được đối tượng";
		}

		public bool isValidate
		{
			get
			{
				return codeError.Equals(_validate);
			}
		}
	}
}
