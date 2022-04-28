using GE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory

    {
        private DbContext dataContext;
        public DbContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new GEContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }

}
