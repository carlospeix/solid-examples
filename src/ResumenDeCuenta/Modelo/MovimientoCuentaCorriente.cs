using System;

namespace ResumenDeCuenta.Modelo
{
	public class MovimientoCuentaCorriente
	{
		public bool EsVisible
		{
			get { return true; }
		}

		public DateTime Fecha
		{
			get { return DateTime.Now; }
		}

		public DateTime FechaAplicacion
		{
			get { return DateTime.Now; }
		}

		public decimal Importe
		{
			get { return 0m; }
		}
	}
}