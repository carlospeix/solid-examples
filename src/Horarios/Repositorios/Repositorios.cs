using ControlHorarios.Modelo;

namespace ControlHorarios.Repositorios
{
	public interface IQueryUltimaAsistencia : IQuery<Asistencia>
	{
		IQuery<Asistencia> WithEmpleado(Empleado empleado);
	}

	public interface IQueryEmpleadoPorLegajo : IQuery<Empleado>
	{
		IQuery<Empleado> WithLegajo(string legajo);
	}
}