using Verificador.Modelo;

namespace Verificador.Servicios
{
	public interface IVerificadorCliente
	{
		EstadoCliente Verificar(Cliente cliente);
	}
}