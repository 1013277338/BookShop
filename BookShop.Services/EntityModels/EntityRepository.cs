//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BookShop.Services.EntityModels
{
	[ExcludeFromCodeCoverage]
	[System.CodeDom.Compiler.GeneratedCode("UnitOfWorkGenerator", "1.0.0.0")]
    public partial class EntityRepository<E> : IRepository<E> where E : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<E> ObjectSet;

        public EntityRepository(DbContext context)
        {
			Contract.Requires(context != null, "context cannot be null.");
            
            this.Context = context;
            this.ObjectSet = context.Set<E>();
        }

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(this.Context != null);
			Contract.Invariant(this.ObjectSet != null);
		}

        public virtual IQueryable<E> Table
        {
			get
			{
				return this.ObjectSet;
			}
        }

        public virtual void Add(E entity)
        {
            this.ObjectSet.Add(entity);
        }

        public virtual void Remove(E entity)
        {
            if (!this.ObjectSet.Local.Contains(entity))
            {
                this.ObjectSet.Attach(entity);
            }

            this.ObjectSet.Remove(entity);
        }

        public virtual int Save()
        {
            return Context.SaveChanges();
        }

		public virtual E Find(params object[] keyValues)
		{
			return this.ObjectSet.Find(keyValues);
		}
    }
}

