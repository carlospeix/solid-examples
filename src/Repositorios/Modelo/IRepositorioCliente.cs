using System.Collections.Generic;

namespace Repositorios.Modelo
{
	public interface IRepositorioCliente : IRepositorio<Cliente>
	{
		Cliente GetByCuit(string cuit);
		IEnumerable<Cliente> GetByProvincia(Provincia provincia);
	}
}