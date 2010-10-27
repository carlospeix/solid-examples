using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Repositorios.Modelo;

namespace Repositorios.Infraestructura
{
	public class RepositorioFacturas : Repositorio<Factura>, IRepositorioFactura
	{
		public RepositorioFacturas(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Factura ObtenerUna(CriteriosFacturas criterios)
		{
			var c = CurrentSession.CreateCriteria<Factura>();

			c.Add(Restrictions.Eq("Numero", criterios.Numero));

			return c.UniqueResult<Factura>();
		}

		public IEnumerable<Factura> ObtenerMuchas(CriteriosFacturas criterios)
		{
			var c = CurrentSession.CreateCriteria<Factura>();

			if (criterios.Cliente != null)
				c.Add(Restrictions.Eq("Cliente", criterios.Cliente));

			if (criterios.Provincia != null)
				c.Add(Restrictions.Eq("Procincia", criterios.Provincia));

			if (!String.IsNullOrEmpty(criterios.Numero))
				c.Add(Restrictions.Eq("Numero", criterios.Numero));

			if (criterios.FechaDesde.HasValue)
				c.Add(Restrictions.Ge("Fecha", criterios.FechaDesde.Value));

			if (criterios.FechaHasta.HasValue)
				c.Add(Restrictions.Le("Fecha", criterios.FechaHasta.Value));

			c.AddOrder(Order.Asc("Fecha"));

			return c.List<Factura>();
		}
	}
}