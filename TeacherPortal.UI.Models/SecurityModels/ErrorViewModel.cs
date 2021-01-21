namespace TeacherPortal.UI.Models.SecurityModels
{
    /// <summary>
    /// Model class for error messages
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
