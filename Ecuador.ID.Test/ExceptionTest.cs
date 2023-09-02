using Ecuador.ID.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Test
{
    public class ExceptionTest
    {
        [Fact]
        public void Test_ReturnStateCodeNotFoundException_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<StateCodeNotFoundException>(() => id.IsValid("9955564315"));
        }

        [Fact]
        public void Test_ReturnThirdDigitNotValidException_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<ThirdDigitNotValidException>(() => id.IsValid("0995564315"));
        }

        [Fact]
        public void Test_ReturnVerifierDigitNotValidException_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<VerifierDigitNotValidException>(() => id.IsValid("0955564319"));
        }

        [Fact]
        public void Test1_ReturnFormatInputNotValidException_LenghtDifferent10_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<FormatInputNotValidException>(() => id.IsValid("00"));
        }

        [Fact]
        public void Test2_ReturnFormatInputNotValidException_CharacterNotValid_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<FormatInputNotValidException>(() => id.IsValid("61057*9398"));
        }

        [Fact]
        public void Test3_ReturnFormatInputNotValidException_EmptyId_ExceptionsEnabled()
        {
            // Arrange
            IDValidator id = new IDValidator(true);

            // Assert
            Assert.Throws<FormatInputNotValidException>(() => id.IsValid(""));
        }

        

    }
}
