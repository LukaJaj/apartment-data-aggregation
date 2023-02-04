using System;
namespace data_aggregation.Models.Exceptions
{
	public class TableAlreadySeededException : Exception
	{
		public TableAlreadySeededException(string message) : base(message)
		{

		}
	}
}

