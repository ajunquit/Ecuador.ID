using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Test
{
    public class DelimiterTest
    {
        [Fact]
        public void Test_ReturnValidIds_WithDelimiter()
        {
            // Arrange
            IDValidator idValidator = new IDValidator();

            // Act
            var result = idValidator.IsValid("0954323176 => 1725353260 =>   0909815094=>=>", "=>");
            var notValidIds = result.Where(x => x.IsValid == false).ToList();
            
            // Assert
            Assert.NotNull(result);
            Assert.True(!notValidIds.Any(), "should return a list with all valid ids.");

        }

        [Fact]
        public void Test_ReturnNotValidIds_WithDelimiter()
        {
            // Arrange
            IDValidator idValidator = new IDValidator();

            // Act
            var result = idValidator.IsValid("9954323176 => 1729353260 =>   0909815099=>=>", "=>");
            var notValidIds = result.Where(x => x.IsValid == false).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.False(!notValidIds.Any(), "should return a list with all invalid ids.");

        }

        [Fact]
        public void Test_ReturnValidAndInvalidIds_WithDelimiter()
        {
            // Arrange
            IDValidator idValidator = new IDValidator();

            // Act
            var result = idValidator.IsValid("0954323176 => 9954323176 =>   09*9815099=>=>", "=>");
            var notValidIds = result.Where(x => x.IsValid == false).ToList().Any();
            var validIds = result.Where(x => x.IsValid == true).ToList().Any();
            
            // Assert
            Assert.NotNull(result);
            Assert.True(validIds == true && notValidIds == true, "should return true due there are valid and invalid ids.");

        }
    }
}
