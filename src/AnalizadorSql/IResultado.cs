namespace AnalizadorSql
{
	public enum TipoResultado
	{
		Ok, Warning, Error
	}

	public interface IResultado
	{
		TipoResultado Tipo { get; }
		string Script { get; }
		string Mensaje { get; }
	}
}