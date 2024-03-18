﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
		private readonly SignalRContext _context;

		public EfCategoryDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public int CategoryCount()
		{
			return _context.Categories.Count();
		}
		public int ActiveCategoryCount()
		{
			return _context.Categories.Where(x=>x.Status==true).Count();
		}
		public int PassiveCategoryCount()
		{
			return _context.Categories.Where(x => x.Status == false).Count();
		}
	}
}
