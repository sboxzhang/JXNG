using System;
using System.Collections.Generic;
using System.Text;
namespace AYJZ.DataAccess
{
	class DataBaseEnum
	{
	}
	public struct DatabaseActions
	{
		public const int Insert = 1;
		public const int Update = 2;
		public const int Delete = 3;
		public const int Query = 4;
		public const int Ingore = 5;
	}
	
	public struct DatabaseExecutionPriorities
	{
		public const int High = 3;
		public const int Normal = 2;
		public const int Low = 1;
	}
	public struct ExecutionPriorities
	{
		public const int High = 3;
		public const int Normal = 2;
		public const int Low = 1;
	}
}