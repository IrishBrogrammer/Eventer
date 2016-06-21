using System;
using System.Linq;
using System.Collections.Generic;


public class EventerTypeContainer
{
	public Dictionary<string,EventerParameterTypeLoader> parameterLoaders = new Dictionary<string,EventerParameterTypeLoader>();
	
	public EventerTypeContainer( Type loaderType )
	{
		var ParameterImplementations = GetParameterTypes( loaderType);
		
		foreach( var param in ParameterImplementations )
		{
			var loader = new EventerParameterTypeLoader( param );
			parameterLoaders.Add( loader.GetKey()  , loader );
		}
	}

	public IEnumerable<Type> GetParameterTypes( Type loaderType )
	{
		Type desiredType = loaderType;
		
		return AppDomain
			   .CurrentDomain
			   .GetAssemblies()
			   .SelectMany( ass => ass.GetTypes() )
			   .Where( type => desiredType.IsAssignableFrom( type ) )
			   .Where( type => IsRealClass( type ) );
	}
	
	private bool IsRealClass( Type testType )
	{
		return testType.IsAbstract == false 
		&& testType.IsInterface == false
		&& testType.IsGenericTypeDefinition == false;
	}
	
	public object CreateInstanceOfType( Dictionary<string,object> fields )
	{
		var keys = fields.Keys.ToList();
		keys.Sort();
		var hash = EventerParameterTypeLoader.GetEventParameterHash( keys );
		return parameterLoaders[hash].CreateInstanceOfType( fields );
	}
	
}