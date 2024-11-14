using System;
using System.ComponentModel.DataAnnotations;

namespace Asp_Identity.ViewModels
{
	public class Register
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public String Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
        public String Password { get; set; }
		[Required]
		[Compare(nameof(Password),ErrorMessage ="Passwords do not match")]
        public String ConfirmPassword { get; set; }

      
		
	}
}

