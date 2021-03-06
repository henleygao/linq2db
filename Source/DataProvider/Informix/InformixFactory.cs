﻿using System;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;

namespace LinqToDB.DataProvider.Informix
{
	using Data;

	public class InformixFactory : IDataProviderFactory
	{
		static readonly InformixDataProvider _informixDataProvider = new InformixDataProvider();

		static InformixFactory()
		{
			DataConnection.AddDataProvider(_informixDataProvider);
		}

		IDataProvider IDataProviderFactory.GetDataProvider(NameValueCollection attributes)
		{
			return _informixDataProvider;
		}

		public static IDataProvider GetDataProvider()
		{
			return _informixDataProvider;
		}

		public static void ResolveInformix(string path)
		{
			new AssemblyResolver(path, "IBM.Data.Informix");
		}

		public static void ResolveInformix(Assembly assembly)
		{
			new AssemblyResolver(assembly, "IBM.Data.Informix");
		}

		#region CreateDataConnection

		public static DataConnection CreateDataConnection(string connectionString)
		{
			return new DataConnection(_informixDataProvider, connectionString);
		}

		public static DataConnection CreateDataConnection(IDbConnection connection)
		{
			return new DataConnection(_informixDataProvider, connection);
		}

		public static DataConnection CreateDataConnection(IDbTransaction transaction)
		{
			return new DataConnection(_informixDataProvider, transaction);
		}

		#endregion
	}
}
