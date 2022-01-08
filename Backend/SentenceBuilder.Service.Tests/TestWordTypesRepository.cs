using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Transactions;
using NUnit.Framework;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service.Tests
{
	public class Tests
	{
		private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=AMSDatabase";
		private TransactionScope _scope;

		[SetUp]
		public void Setup()
		{
			_scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
		}

		[TearDown]
		public void TearDown()
		{
			_scope.Dispose();
		}

		[Test]
		public async Task GetAllWordTypes_WhenCalled_ShouldReturnAllWordTypes()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);

			//Act
			var actual = await sut.GetAllWordTypes();

			//Assert
			//Assert.IsTrue(dataLength > 0, "Database must not be empty");
			//Assert.IsTrue(dataLength >= 50, "Database records should be 50 or more");

		}

		private static IWordTypeRepository CreateWordTypeRepository(string connectionString)
		{
			IWordTypeRepository wordTypeRepository = new WordTypeRepository(connectionString);
			return wordTypeRepository;
		}
	}
}