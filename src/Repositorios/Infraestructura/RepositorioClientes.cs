using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Repositorios.Modelo;

namespace Repositorios.Infraestructura
{
	public class RepositorioClientes : Repositorio<Cliente>, IRepositorioCliente
	{
		public RepositorioClientes(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Cliente GetByCuit(string cuit)
		{
			var c = CurrentSession.CreateCriteria<Cliente>();

			c.Add(Restrictions.Eq("Cuit", cuit));

			return c.UniqueResult<Cliente>();
		}

		public IEnumerable<Cliente> GetByProvincia(Provincia provincia)
		{
			var c = CurrentSession.CreateCriteria<Cliente>();

			c.Add(Restrictions.Eq("Provincia", provincia));

			c.AddOrder(Order.Asc("RazonSocial"));

			return c.List<Cliente>();
		}
	}
}