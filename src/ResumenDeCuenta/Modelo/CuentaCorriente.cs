using System.Linq;
using System.Collections.Generic;

namespace ResumenDeCuenta.Modelo
{
	public class CuentaCorriente
	{
		private readonly IEnumerable<MovimientoCuentaCorriente> _movimientos;

		public IEnumerable<MovimientoResumenDeCuenta> ResumentDeCuenta()
		{
			// Si esta activa solo se muestran los movimientos
			// visibles y ordenados por fecha de aplicacion
			if (Activa)
			{
				return _movimientos.AsQueryable().
					Where(m => m.EsVisible).
					OrderBy(m => m.FechaAplicacion).
					Select(m => new MovimientoResumenDeCuenta(m));
			}

			// Caso contrario se muestran todos ordenados por 
			// fecha del movimiento
			return _movimientos.AsQueryable().
				OrderBy(m => m.Fecha).
				Select(m => new MovimientoResumenDeCuenta(m));
		}

		public bool Activa
		{
			get { return true; }
		}
	}
}