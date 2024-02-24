namespace MvcMovies.Models
{
    //determines whether or not an error occurs dependent on what was entered/not entered
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
