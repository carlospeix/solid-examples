using Verificador.Servicios;

namespace Verificador.Modelo
{
	public class IncorporadorDeClientes
	{
		private readonly IRepositorioClientes _repositorio;
		private readonly IVerificadorCliente _verificadorCliente;

		public IncorporadorDeClientes(
			IRepositorioClientes repositorio,
			IVerificadorCliente verificadorCliente)
		{
			_repositorio = repositorio;
			_verificadorCliente = verificadorCliente;
		}

		public void RegistrarCliente(string cuit, string descripcion)
		{
			var cliente = new Cliente {Cuit = cuit, Descripcion = descripcion};

			cliente.Estado = _verificadorCliente.Verificar(cliente);

			_repositorio.Agregar(cliente);
		}
	}
}