using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Verificador.Servicios;

namespace Verificador.Modelo
{
	public class IncorporadorDeClientes
	{
		private readonly IRepositorioClientes _repositorio;

		public IncorporadorDeClientes(IRepositorioClientes repositorio)
		{
			_repositorio = repositorio;
		}

		public void RegistrarCliente(string cuit, string descripcion)
		{
			var cliente = new Cliente {Cuit = cuit, Descripcion = descripcion};

			VerificarFabrikam(cliente);

			_repositorio.Agregar(cliente);
		}

		public void VerificarFabrikam(Cliente cliente)
		{
			if (cliente.Estado == EstadoCliente.NoEspecificado)
				return;

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
						cliente.Estado = EstadoCliente.Aprobado;

					cliente.Estado = EstadoCliente.Rechazado;
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