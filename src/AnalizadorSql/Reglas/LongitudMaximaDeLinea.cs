namespace AnalizadorSql.Reglas
{
	public class LongitudMaximaDeLinea : IReglaAnalisis
	{
		public LongitudMaximaDeLinea(string nivel)
		{
		}

		public IResultado[] Analizar(string scriptPath)
		{
			return new IResultado[] { };
		}
	}
}
