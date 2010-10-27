using System;

namespace ControlHorarios.Repositorios
{
	public interface IRepositorio<T> where T : class
	{
		T Get(Guid id);
		void Add(T entity);
		void Delete(T entity);
	}
}