namespace CalorieCalculator.API
{
    public class ValidatorResult
    {
        public bool IsValid 
        {
            get { return string.IsNullOrWhiteSpace(ErrorMessage); }
        }
        public string ErrorMessage { get; set; }

        public ValidatorResult(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }
    }
}
