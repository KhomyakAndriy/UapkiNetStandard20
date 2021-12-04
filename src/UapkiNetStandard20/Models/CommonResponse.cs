namespace UapkiNetStandard20.Models
{
    public class CommonResponse<T>
    {
        public int ErrorCode { get; set; }

        public string Error { get; set; }

        public string Method { get; set; }

        public T Result { get; set; }

        public bool IsSuccess => ErrorCode == 0;
    }
}
