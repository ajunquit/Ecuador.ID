using Ecuador.ID.Exceptions;

namespace Ecuador.ID.Test
{
    public class ValidTest
    {
        [Fact]
        public void Test_ReturnValidID_WhenVerifierDigitIsZero()
        {
            // Arrange
            IDValidator id = new IDValidator();

            // Act
            var response = id.IsValid("1725353260");

            // Assert
            Assert.True(response.IsValid, response.Message);
        }

        [Fact]
        public void Test_ReturnValidID_WhenVerifierDigitIsDifferentZero()
        {
            // Arrange
            IDValidator id = new IDValidator();

            // Act
            var response = id.IsValid("0954787644");

            // Assert
            Assert.True(response.IsValid, response.Message);
        }

      

        [Fact]
        public void TestListIds_ReturnValidIds_LoadedFromValidFileWithValidIds()
        {
            // Arrange
            IDValidator idValidator = new IDValidator();
            string currentPath = Directory.GetCurrentDirectory();
            var contentFile = File.ReadAllLines(Path.Combine(currentPath, "EcuadorValidIDs.txt"));
            List<string> ids = contentFile.Select(x => x.Trim()).ToList();

            // Act
            var result = idValidator.IsValid(ids);

            var notValidIds = result.Where(x => x.IsValid == false).ToList();
            string messages = string.Join(";", notValidIds.Select(x => x.Message));

            // Assert
            Assert.NotNull(result);
            Assert.True(!notValidIds.Any(), messages);

        }


       
    }
}