namespace AllBuyMyself.Models.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; } = false;
        public T? Result { get; set; } = default;
        public string ErrorMessage { get; set; } = string.Empty;

        public ApiResult(T result)
        {
            IsSuccess = true;
            Result = result;
            ErrorMessage = string.Empty;
        }
    }
}
