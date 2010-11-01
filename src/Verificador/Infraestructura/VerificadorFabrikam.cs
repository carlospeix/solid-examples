using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Verificador.Modelo;
using Verificador.Servicios;

namespace Verificador.Infraestructura
{
	public class VerificadorFabrikam : IVerificadorCliente
	{
		public EstadoCliente Verificar(Cliente cliente)
		{
			try
			{
				using (var connection = new SqlConnection(
					ConfigurationManager.AppSettings["validacionConnectionString"]))
				{
					connection.Open();
					var command = connection.CreateCommand();
					command.CommandText = "select * from vPadDgi where cuit = @cuit";
					command.Parameters.Add("@cuit", SqlDbType.VarChar).Value = cliente.Cuit;

					var reader = command.ExecuteReader();
					if (reader != null && reader.Read())
						return EstadoCliente.Aprobado;

					return EstadoCliente.Rechazado;
				}
			}
			catch (Exception ex)
			{
				// log.Error("Error en la validacion de padron", ex);
				Console.WriteLine("Error en la validacion de padron: {0}", ex);
				throw;
			}
		}
	}
}