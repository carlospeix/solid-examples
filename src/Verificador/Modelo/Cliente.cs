namespace Verificador.Modelo
{
	public class Cliente
	{
		public string Descripcion { get; set; }
		public string Cuit { get; set; }
		public EstadoCliente Estado { get; set; }
	}

	public enum EstadoCliente
	{
		NoEspecificado,
		Rechazado,
		Aprobado
	}
}