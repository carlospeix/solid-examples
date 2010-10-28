// Se pretende tener un tipo de proyecto (template)
// de visual studio que gestione ficheros sql de Oracle.
// Habría una tarea de MSBuild que se llamaría desde esos 
// tipos de proyectos y que analizaría los ficheros sql, con 
// una serie de reglas definidas en un .config.

// El ParserSQL o Analizador leería el fichero de configuración, y por
// reflexión determinaría las reglas que se tendrían que ejecutar sobre
// esos ficheros.

// Internamente, muchas  reglas utilizarían ANTLR para realizar un
// análisis sintáctico y semántico. Otras en cambio no utilizarían
// gramáticas.


// La ejecución de las reglas deberían devolver una lista de resultados
// (si hay errores, o warnings) y quizá también escribir ficheros del log
// (en formato texto o xml) con toda la información del análisis.

// Cómo sería un buen diseño y patrones en este caso ??

using System;
using System.IO;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace AnalizadorSql
{
	public class Principal
	{
		[STAThread]
		static void Main()
		{
			using (var container = new WindsorContainer())
			{
				// Necesario para que resuelva la dependecia de IReglaAnalisis[] reglas
				// en la clase Analizador
				container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
				container.Install(Castle.Windsor.Installer.Configuration.FromXmlFile("castle.config"));

				var analizador = container.Resolve<Analizador>();
				var notificador = container.Resolve<Notificador>();

				foreach (var script in Directory.GetFiles("C:\\Scripts\\"))
				{
					var resultados = analizador.Analizar(script);
					notificador.Notificar(resultados);
				}
			}
		}
	}
}
