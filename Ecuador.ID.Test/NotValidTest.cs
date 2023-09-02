using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Test
{
    public class NotValidTest
    {
        [Fact]
        public void Test_ReturnNotValidId_WhenThirdDigitIsGreaterThaOrEqualTo6()
        {
            // Arrange
            IDValidator id = new IDValidator();

            // Act
            var response = id.IsValid("0964098643");

            // Assert
            Assert.False(response.IsValid, response.Message);
        }

        [Fact]
        public void Test_ReturnNotValidId_WhenVerifierDigitIsNotValid()
        {
            // Arrange
            IDValidator id = new IDValidator();

            // Act
            var response = id.IsValid("0964098649");

            // Assert
            Assert.False(response.IsValid, response.Message);
        }


        [Fact]
        public void TestListIds_ReturnNotValidIds_LoadedFromNotValidFileWithInvalidIds()
        {
            // Arrange
            IDValidator idValidator = new IDValidator();
            string currentPath = Directory.GetCurrentDirectory();
            var contentFile = File.ReadAllLines(Path.Combine(currentPath, "EcuadorNotValidIDs.txt"));
            List<string> ids = contentFile.ToList();

            // Act
            var result = idValidator.IsValid(ids);

            var notValidIds = result.Where(x => x.IsValid == false).ToList();
            string messages = string.Join(";", notValidIds.Select(x => x.Message));

            // Assert
            Assert.NotNull(result);
            Assert.False(!notValidIds.Any(), messages);

        }


    }
}
