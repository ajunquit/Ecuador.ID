using Ecuador.ID.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Util
{
    public class CalculatorVerifierDigit
    {
        private static readonly int[] CoefficientsIds = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

        public static int CalculateVerifierDigit(DocumentType documentType, char[] parsedId)
        {
            switch (documentType)
            {
                case DocumentType.ID:
                    return CalculateVerifierDigit(parsedId);

                default: throw new Exception("Verifier Digit Calculator Unknow.");
            }
        }
        private static int CalculateVerifierDigit(char[] parsedId)
        {
            int sum = 0;

            for (int i = 0; i < parsedId.Length - 1; i++)
            {
                int prod = int.Parse(parsedId[i].ToString()) * CoefficientsIds[i];
                sum += prod >= 10 ? prod - 9 : prod;
            }
            int nextTenMultiply = GetNextTenMultiple(sum);
            int verifierDigit = nextTenMultiply - sum;
            return verifierDigit == 10 ? 0 : verifierDigit;
        }

        private static int GetNextTenMultiple(int value)
        {
            return (value - value % 10) + 10;
        }

    }
}
