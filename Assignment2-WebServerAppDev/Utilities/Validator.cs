using Assignment2_WebServerAppDev.Interfaces;

namespace Assignment2_WebServerAppDev.Utilities
{
    public class Validator : IValidator
    {
        bool IsTruthy = false;

        public Validator()
        {
        }

        public Validator(bool isTruthy)
        {
            IsTruthy = isTruthy;
        }

        public bool IsValid(string value)
        {
            return true;
        }
    }
}
