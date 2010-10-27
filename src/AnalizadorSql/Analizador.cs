using System.Collections.Generic;

namespace AnalizadorSql
{
	public class Analizador
	{
		private readonly IReglaAnalisis[] _reglas;

		public Analizador(IReglaAnalisis[] reglas)
		{
			_reglas = reglas;
		}

		public IResultado[] Analizar(string scriptPath)
		{
			var resultados = new List<IResultado>();

			foreach (var regla in _reglas)
			{
				resultados.AddRange(regla.Analizar(scriptPath));
			}

			return resultados.ToArray();
		}
	}
}
