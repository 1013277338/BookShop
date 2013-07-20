//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;

namespace BookShop.Services.EntityModels
{
    [ContractClassFor(typeof(IRepository<>))]
    abstract class RepositoryContract<T> : IRepository<T>
    {
		[ContractInvariantMethod]
		private void ObjectInvariant() 
		{
			Contract.Invariant(this.Table != null);
		}

        public IQueryable<T> Table
        {
            get 
            {
                Contract.Ensures(Contract.Result<IQueryable<T>>() != null);
                throw new NotImplementedException(); 
            }
        }

        public void Add(T entity)
        {
            Contract.Requires(entity != null, "entity cannot be null.");
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            Contract.Requires(entity != null, "entity cannot be null.");
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            Contract.Requires(keyValues != null, "keyValues cannot be null.");
			Contract.Requires(keyValues.Length > 0, "keyValues cannot be empty.");
            throw new NotImplementedException();
        }
    }
}
