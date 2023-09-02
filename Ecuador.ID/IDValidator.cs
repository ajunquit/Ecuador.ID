using Ecuador.ID.Dto;
using Ecuador.ID.Enums;
using Ecuador.ID.Exceptions;
using Ecuador.ID.Interfaces;
using Ecuador.ID.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID
{
    public class IDValidator: IIDValidator
    {
        private bool EnableExceptionsThrows { get; }
        
        private InfoID InfoID { get; set; }

        public IDValidator(): this(false)
        {
        }

        public IDValidator(bool enableExceptionsThrows)
        {
            this.EnableExceptionsThrows = enableExceptionsThrows;
        }
       

        public List<InfoID> IsValid(List<string> ids)
        {
            ids = ids.Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            return ids.Select(IsValid).ToList();
        }

        public List<InfoID> IsValid(string ids, string delimiter)
        {
            List<string> delimitedIds = ids.Split(delimiter).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            return IsValid(delimitedIds);
        }

        public InfoID IsValid(string id)
        {
            this.InfoID = GetInstanceInfoIdWithDefaultValues(id);
            try
            {
                if (IsInputValid(id))
                {
                    var parsedId = id.ToCharArray();

                    string stateCode = id.Substring(0, 2);
                    bool isStateCodeValid = CheckStateCode(stateCode);

                    int thirdDigit = (int)int.Parse(parsedId[2].ToString());
                    bool isThirdDigitValid = CheckThirdDigit(thirdDigit);

                    string consequentNumber = id.Substring(3, 6);
                    bool isConsequentNumberValid = CheckConsequentNumber(consequentNumber);

                    int verifierDigitCalculated = CalculatorVerifierDigit.CalculateVerifierDigit(DocumentType.ID, parsedId);
                    bool isVerifierDigitValid = CheckIfVerifierDigitIsValid(verifierDigitCalculated, parsedId[9]);

                    InfoID.IsValid = 
                        isStateCodeValid
                        && isThirdDigitValid
                        && isConsequentNumberValid
                        && isVerifierDigitValid;

                    InfoID.Message = InfoID.IsValid ? "ID is Valid" : "ID is not valid.";
                }
            }
            catch (Exception ex)
            {
                InfoID.IsValid = false;
                InfoID.Message = ex.Message;
                InfoID.Exceptions.Add(ex);
                if (EnableExceptionsThrows)
                    throw;
            }
            return this.InfoID;
        }

        private InfoID GetInstanceInfoIdWithDefaultValues(string id)
        {
            return new InfoID
            {
                ID = id,
                IsValid = false,
                Message = string.Empty,
                Type = DocumentType.ID
            };
        }

        private bool IsInputValid(string id)
        {
            bool isValid = !string.IsNullOrEmpty(id) && id.Length == 10 && id.All(char.IsNumber);
            if (!isValid)
            {
                string message = string.Format("Bad format. ID: {0}", id);
                var exception = new FormatInputNotValidException(message, id);
                if (EnableExceptionsThrows)
                    throw exception;
                else
                    AddException(exception);
                return false;
            }
            return true;
        }

        private bool CheckStateCode(string stateCode)
        {
            bool isValid = StateDictionary.States.Where(x => x.Key.Equals(stateCode)).Any();
            if (!isValid)
            {
                string message = GetFormattedMessage("State code not valid.", "State Code", stateCode);
                var exception = new StateCodeNotFoundException(message, stateCode, InfoID.ID);
                if (EnableExceptionsThrows)
                    throw exception;
                else
                    AddException(exception);                
                return false;
            }
            return true;
        }

        private bool CheckThirdDigit(int thirdDigit)
        {
            if (thirdDigit < 0 || thirdDigit > 5)
            {
                string message = GetFormattedMessage("Third Digit is Not valid.", "Third Digit", thirdDigit.ToString());
                var exception = new ThirdDigitNotValidException(message, thirdDigit);
                if (EnableExceptionsThrows)
                    throw exception;
                else
                    AddException(exception);
                return false;
            }
            return true;
        }

        private bool CheckConsequentNumber(string consequentNumber)
        {
            if (!long.TryParse(consequentNumber, out var parsedNumber))
            {
                string message = GetFormattedMessage("Consequent number is Not Valid.", "Consequent Number", consequentNumber);
                var exception = new ConsequentNumberNotValidException(message, consequentNumber);
                if (EnableExceptionsThrows)
                    throw exception;
                else
                    AddException(exception);
                return false;
            }
            return true;
        }

        private bool CheckIfVerifierDigitIsValid(int verifierDigitCalculated, char verifierDigitExpected)
        {
            if (verifierDigitCalculated != int.Parse(verifierDigitExpected.ToString()))
            {
                string message = GetFormattedMessage("Verifier Digit is Not Valid.", "Verifier Digit", verifierDigitExpected.ToString());
                var exception = new VerifierDigitNotValidException(message, verifierDigitExpected.ToString());
                if (EnableExceptionsThrows)
                    throw exception;
                else
                    AddException(exception);
                return false;
            }
            return true;
        }

        private string GetFormattedMessage(string message, string field, string valueField)
        {
            return string.Format("Message: {0} ID: {1} " + field + ": {2}", message, InfoID.ID, valueField);
        }

        private void AddException(Exception exception)
        {
            InfoID.Exceptions.Add(exception);
        }

        

    }
}
