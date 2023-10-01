namespace OstringsAdmin.Services.Base
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public string ReturnUrl { get; set; }
        public List<RepositoryError> CustomErrors { get; set; }
        public bool IsSucces { get; set; }
    }

    public class ResponseBase
    {
        public string ReturnUrl { get; set; }
        public List<RepositoryError> CustomErrors { get; set; }
        public bool IsSucces { get; set; }
    }
}
