// At the moment the json library used cannot support loosely defined types
// However if we can make a guess at the object type based of the field names provided in the json
// and comparing them to the arguments in the constructors of the classes that implement IConditionParameters
using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class EventerParameterTypeLoader
{
	private string Key;
	private Type   ParameterType;
	
	public EventerParameterTypeLoader( Type paramType )
	{
		ParameterType = paramType;
		
		var constructors = paramType.GetConstructors();
		
		if ( constructors.Length > 1 )
		{
			Debug.Log( "Trying to load a parameter type with more than one constructor,I can't let you do that Dave" );
			return;
		}
		
		var ValidConstructor = constructors[0];
		var ParamNames = ValidConstructor.GetParameters().Select( param => param.Name ).ToList();		
		Key = GetEventParameterHash( ParamNames );
	}
	
	
	public object CreateInstanceOfType( Dictionary<string,object> fields )
	{
		var ctor = ParameterType.GetConstructors()[0];
		
		var ctorParams = ctor.GetParameters();
		
		object[] args = new object[ctorParams.Count()];
		
		int i = 0;
		foreach( var param in ctorParams )
		{
			string name = param.Name;
			
			if ( fields.ContainsKey( name ) )
			{
				args[i] = fields[name];
			}
			else
			{
				Debug.Log( " Could not find field " + name );
			}
			i++;
		}
	
		return Activator.CreateInstance( ParameterType , args );	
	}
	
	
	public string GetKey()
	{
		return Key;
	}

	//Super secret algo/ Sort fields alphabetically then add them together
	public static string GetEventParameterHash( List<string> eventParamers )
	{
		eventParamers.Sort();	
		string hash = string.Empty;
		eventParamers.ForEach(  key => hash += key);
		return hash;
	}	
}
	
	

