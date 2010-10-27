using System;
using System.Collections.Generic;

namespace Repositorios.Modelo
{
	public interface IRepositorioFactura : IRepositorio<Factura>
	{
		Factura ObtenerUna(CriteriosFacturas criterios);
		IEnumerable<Factura> ObtenerMuchas(CriteriosFacturas criterios);
	}

	public class CriteriosFacturas
	{
		public string Numero { get; set; }
		public Cliente Cliente { get; set; }
		public Provincia Provincia { get; set; }
		public DateTime? FechaDesde { get; set; }
		public DateTime? FechaHasta { get; set; }
	}
}