using System;

namespace ControlHorarios.Modelo
{
	public class Empleado
	{
		private readonly Horario _horario;

		public Empleado(Horario horario)
		{
			_horario = horario;
		}

		public Alerta VerificarIngreso(DateTime horarioIngreso)
		{
			// En horario variable no verificamos ingreso
			if (_horario is HorarioVariable)
				return new Alerta("");

			// En horario fijo verificamos contra hora inicial
			if (_horario is HorarioFijo)
			{
				var horarioFijo = _horario as HorarioFijo;

				if (horarioIngreso > ConvertirAHoraHoy(horarioFijo.HoraIngreso))
					return new Alerta("Alerta! ingreso tarde.");

				return new Alerta("");
			}

			return new Alerta("Alerta! horario invalido: " + _horario.GetType().Name);
		}

		public Alerta VerificarEgreso(DateTime horarioIngreso, DateTime horarioEgreso)
		{
			// En horario variable verificamos las horas trabajadas
			if (_horario is HorarioVariable)
			{
				var horarioVariable = _horario as HorarioVariable;

				if (horarioEgreso.Subtract(horarioIngreso) < horarioVariable.TiempoMinimo)
					return new Alerta("Alerta! tiempo minimo incumplido.");

				return new Alerta("");
			}

			// En horario fijo verificamos contra hora final
			if (_horario is HorarioFijo)
			{
				var horarioFijo = _horario as HorarioFijo;

				if (DateTime.Now < ConvertirAHoraHoy(horarioFijo.HoraEgreso))
					return new Alerta("Alerta! egreso temprano.");

				return new Alerta("");
			}

			return new Alerta("Alerta! horario invalido: " + _horario.GetType().Name);
		}

		private static DateTime ConvertirAHoraHoy(DateTime hora)
		{
			var now = DateTime.Now;
			return new DateTime(now.Year, now.Month, now.Day, hora.Hour, hora.Minute, 0);
		}

	}
}