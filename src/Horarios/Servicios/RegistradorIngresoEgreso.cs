using System;
using ControlHorarios.Modelo;
using ControlHorarios.Repositorios;

namespace ControlHorarios.Servicios
{
	public class RegistradorIngresoEgreso
	{
		private readonly IQueryUltimaAsistencia _queryUltimaAsistencia;
		private readonly IQueryEmpleadoPorLegajo _queryEmpleadoPorLegajo;
		private readonly IRepositorio<Alerta> _repositorioAlertas;
		private readonly IRepositorio<Asistencia> _repositorioAsistencias;

		public RegistradorIngresoEgreso(
			IQueryUltimaAsistencia queryUltimaAsistencia,
			IQueryEmpleadoPorLegajo queryEmpleadoPorLegajo,
			IRepositorio<Alerta> repositorioAlertas,
			IRepositorio<Asistencia> repositorioAsistencias)
		{
			_queryUltimaAsistencia = queryUltimaAsistencia;
			_queryEmpleadoPorLegajo = queryEmpleadoPorLegajo;
			_repositorioAlertas = repositorioAlertas;
			_repositorioAsistencias = repositorioAsistencias;
		}

		public void RegistrarIngreso(string legajo)
		{
			var empleado = _queryEmpleadoPorLegajo.WithLegajo(legajo).GetUnique();

			var asistencia = new Asistencia(empleado, DateTime.Now);

			var alerta = empleado.VerificarIngreso(asistencia.Ingreso);

			if (alerta.Mensaje != "")
				_repositorioAlertas.Add(alerta);

			_repositorioAsistencias.Add(asistencia);
		}

		public void RegistrarEgreso(string legajo)
		{
			var empleado = _queryEmpleadoPorLegajo.WithLegajo(legajo).GetUnique();

			var asistencia = 
				_queryUltimaAsistencia.WithEmpleado(empleado).GetUnique();

			asistencia.InformarEgreso(DateTime.Now);

			var alerta = 
				empleado.VerificarEgreso(asistencia.Ingreso, asistencia.Egreso);

			if (alerta.Mensaje != "")
				_repositorioAlertas.Add(alerta);
		}
	}
}
