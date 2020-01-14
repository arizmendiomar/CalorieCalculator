using System;

namespace CalorieCalculator.API
{
    public enum ErrorHandlingType
    { 
        ConsoleLog,
        ThrowException
    }

    public class ErrorHandler
    {
        private ErrorHandlingType _errorHandlingType;

        public ErrorHandler(ErrorHandlingType errorHandlingType)
        {
            _errorHandlingType = errorHandlingType;
        }

        public void Handle(string message)
        {
            switch (_errorHandlingType)
            {
                case ErrorHandlingType.ConsoleLog:
                    Console.WriteLine(message);
                    break;

                case ErrorHandlingType.ThrowException:
                    throw new Exception(message);
            }
        }
    }
}
