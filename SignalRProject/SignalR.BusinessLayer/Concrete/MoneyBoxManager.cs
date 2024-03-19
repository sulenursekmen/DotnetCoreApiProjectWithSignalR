using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MoneyBoxManager : IMoneyBoxService
	{
		private readonly IMoneyBoxDal _moneyBoxDal;

		public MoneyBoxManager(IMoneyBoxDal moneyBoxDal)
		{
			_moneyBoxDal = moneyBoxDal;
		}

		public void TAdd(MoneyBox entity)
		{
			_moneyBoxDal.Add(entity);
		}

		public void TDelete(MoneyBox entity)
		{
			_moneyBoxDal.Delete(entity);
		}

		public MoneyBox TGetByID(int id)
		{
			return _moneyBoxDal.GetByID(id);
		}

		public List<MoneyBox> TGetListAll()
		{
			return _moneyBoxDal.GetListAll();
		}

		public decimal TTotalMoneyBoxAmount()
		{
			return _moneyBoxDal.TotalMoneyBoxAmount();
		}

		public void TUpdate(MoneyBox entity)
		{
			_moneyBoxDal.Update(entity);
		}
	}
}
