using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jewellery.Enities
{
	public sealed class EnumerationHelper<T>
		where T : AbstractEnumeration
	{
		private static Dictionary<int, T> _enumerations;

		public IEnumerable<T> GetAll()
		{
			if (_enumerations == null)
			{
				var fields = typeof(T).GetFields(BindingFlags.Public |
												 BindingFlags.Static |
												 BindingFlags.DeclaredOnly);

				_enumerations = new Dictionary<int, T>();
				foreach (var fieldInfo in fields)
				{
					if (fieldInfo.GetValue(null) is T field)
						_enumerations.Add(field.Id, field);
					else
						throw new Exception("Mixed type specified in enumeration");
				}
			}

			return _enumerations.Values.ToList();
		}

		public T GetById(int id)
		{
			if (_enumerations.ContainsKey(id) == false)
				throw new Exception($"ID: {id} doesn't exist in type");

			return _enumerations[id];
		}
	}
}
