namespace AnalizadorSql
{
	public interface IReglaAnalisis
	{
		IResultado[] Analizar(string scriptPath);
	}
}
