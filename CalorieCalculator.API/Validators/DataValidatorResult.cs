namespace CalorieCalculator.API.Validators
{
    public class DataValidatorResult<T> : ValidatorResult
    {
        public T data { get; set; }

        public DataValidatorResult(T data, string errorMessage = null) : base(errorMessage)
        {
           this.data = data;
        }
    }
}
