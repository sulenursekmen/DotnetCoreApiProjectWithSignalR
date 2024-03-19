using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMoneyBoxDal : GenericRepository<MoneyBox>, IMoneyBoxDal
	{
		private readonly SignalRContext _context;
		public EfMoneyBoxDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public decimal TotalMoneyBoxAmount()
		{
			return _context.MoneyBoxes.Select(x=>x.TotalAmount).FirstOrDefault();
		}
	}
}


