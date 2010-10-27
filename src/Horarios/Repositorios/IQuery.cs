using System.Collections.Generic;

namespace ControlHorarios.Repositorios
{
	public interface IQuery<T> where T : class
	{
		T GetUnique();
		IEnumerable<T> Get(int pageSize, int pageNumber);
	}
}