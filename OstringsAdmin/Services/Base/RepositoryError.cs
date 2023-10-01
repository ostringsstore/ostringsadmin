using OstringsAdmin.Enumerations;

namespace OstringsAdmin.Services.Base
{
    public class RepositoryError
    {
        public string Error { get; set; }
        public string Description { get; set; }
        public StatusResponse Status { get; set; }
    }
}
