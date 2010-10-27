using System.Collections.Generic;

namespace Repositorios.Modelo
{
	public interface IRepositorioProducto : IRepositorio<Producto>
	{
		Producto GetByCodigo(string codigo);
		IEnumerable<Producto> GetByCategoria(string categoria);
	}
}