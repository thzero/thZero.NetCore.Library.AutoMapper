/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.AutoMapper
Copyright (C) 2016-2018 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;

using AutoMapper;

namespace thZero
{
	public static class AutoMapperUtility
	{
		#region Public Methods
		public static IMappingExpression<TSource, TDestination> CreateMapForEntityToObject<TSource, TDestination>(IMapperConfigurationExpression ex)
			where TSource : class
			where TDestination : class
		{
			return ex.CreateMap<TSource, TDestination>();
		}

		public static void MapEntityData<TSource>(TSource source, TSource destination)
			where TSource : class
		{
			Mapper.Map<TSource, TSource>(source, destination);
		}

		public static TSource MapEntityData<TSource>(TSource source)
			where TSource : class
		{
			TSource destination = System.Activator.CreateInstance<TSource>();
			Mapper.Map<TSource, TSource>(source, destination);
			return destination;
		}

		public static void MapEntityData<TSource, TDestination>(TSource source, TDestination destination)
			where TSource : class
			where TDestination : class
		{
			Mapper.Map<TSource, TDestination>(source, destination);
		}

		public static TDestination MapEntityData<TSource, TDestination>(TSource source)
			where TSource : class
			where TDestination : class
		{
			TDestination destination = System.Activator.CreateInstance<TDestination>();
			Mapper.Map<TSource, TDestination>(source, destination);
			return destination;
		}
		#endregion

		#region Private Methods
		private static IMappingExpression<TSource, TDestination> IgnoreAllUnmapped<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
		{
			//Enforce.AgainstNull(() => expression);

			expression.ForAllMembers(opt => opt.Ignore());
			return expression;
		}
		#endregion
	}
}