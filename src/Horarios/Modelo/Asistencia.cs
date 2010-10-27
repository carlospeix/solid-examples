using System;

namespace ControlHorarios.Modelo
{
	public class Asistencia
	{
		public readonly Empleado Empleado;
		public readonly DateTime Ingreso;
		public DateTime Egreso;

		public Asistencia(Empleado empleado, DateTime ingreso)
		{
			Empleado = empleado;
			Ingreso = ingreso;
		}

		public void InformarEgreso(DateTime egreso)
		{
			Egreso = egreso;
		}
	}
}