using System;
using Repositorios.Modelo;

namespace Repositorios.Servicios
{
	public class ServicioFacturacion
	{
		private readonly IRepositorioFactura _repositorioFactura;
		private readonly IRepositorioCliente _repositorioCliente;
		private readonly IRepositorioProducto _repositorioProducto;

		public ServicioFacturacion(
			IRepositorioFactura repositorioFactura, 
			IRepositorioCliente repositorioCliente,
			IRepositorioProducto repositorioProducto)
		{
			_repositorioFactura = repositorioFactura;
			_repositorioCliente = repositorioCliente;
			_repositorioProducto = repositorioProducto;
		}

		public Guid CrearFacturaParaCliente(Guid idCliente)
		{
			var cliente = _repositorioCliente.Get(idCliente);
			var factura = new Factura { Cliente = cliente };
			_repositorioFactura.Add(factura);
			return factura.Id;
		}

		public void AgregarProducto(Guid idFactura, string codigoProducto)
		{
			var factura = _repositorioFactura.Get(idFactura);

			var producto = _repositorioProducto.GetByCodigo(codigoProducto);

			factura.AddProducto(producto);
		}
	}
}