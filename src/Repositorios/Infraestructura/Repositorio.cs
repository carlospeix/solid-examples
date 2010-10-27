using System;
using NHibernate;
using Repositorios.Modelo;

namespace Repositorios.Infraestructura
{
	public abstract class Repositorio<T> : IRepositorio<T> where T : class
	{
		private readonly ISessionFactory _sessionFactory;

		protected Repositorio(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		protected ISession CurrentSession
		{
			get { return _sessionFactory.GetCurrentSession(); }
		}

		public T Get(Guid id)
		{
			return CurrentSession.Get<T>(id);
		}

		public void Add(T entity)
		{
			CurrentSession.SaveOrUpdate(entity);
		}

		public void Delete(T entity)
		{
			CurrentSession.Delete(entity);
		}
	}
}