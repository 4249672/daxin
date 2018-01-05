using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace DX.Loan.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=Loan; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Loan");
        }
    }
}
