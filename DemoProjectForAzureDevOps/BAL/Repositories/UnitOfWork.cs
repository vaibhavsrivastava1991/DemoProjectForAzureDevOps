using DAL.DbContextSettings;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly MVCApplicationDbContext dbContext;
		public UnitOfWork()
		{
			this.dbContext = new MVCApplicationDbContext();
			this.LoginRepository = new LoginRepository(dbContext);
			this.SignupRepository = new SignupRepository(dbContext);
		}

		public ILoginRepository LoginRepository { get; private set; }

		public ISignupRepository SignupRepository { get; private set; }
		public int Complete()
		{
			return dbContext.SaveChanges();
		}
		public void Dispose()
		{
			dbContext.Dispose();
		}
	}
}
