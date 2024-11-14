using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Asp_Identity.Models
{
	public class AuthDBContext: IdentityDbContext
	{
		public AuthDBContext(DbContextOptions<AuthDBContext> options): base(options)
		{
		}
	}
}

