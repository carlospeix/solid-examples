using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Repositorios.Modelo;

namespace Repositorios.Infraestructura
{
	public class RepositorioProductos : Repositorio<Producto>, IRepositorioProducto
	{
		public RepositorioProductos(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Producto GetByCodigo(string codigo)
		{
			var c = CurrentSession.CreateCriteria<Producto>();

			c.Add(Restrictions.Eq("Codigo", codigo));

			return c.UniqueResult<Producto>();
		}

		public IEnumerable<Producto> GetByCategoria(string categoria)
		{
			var c = CurrentSession.CreateCriteria<Producto>();

			c.Add(Restrictions.Eq("Categoria", categoria));

			c.AddOrder(Order.Asc("Descripcion"));

			return c.List<Producto>();
		}
	}
}