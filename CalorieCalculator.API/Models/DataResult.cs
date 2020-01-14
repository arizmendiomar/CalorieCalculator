namespace CalorieCalculator.API.Models
{
    public class DataResult<T>
    {
        public T Data { get; set; }

        public bool Invalid { get; set; }

        public DataResult(T data, bool invalid)
        {
            this.Data = data;
            this.Invalid = invalid;
        }
    }
}
