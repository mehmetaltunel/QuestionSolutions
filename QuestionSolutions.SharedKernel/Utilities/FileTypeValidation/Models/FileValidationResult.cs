namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models
{
    public class FileValidationResult
    {
        public FileMimeType MimeType { get; set; }
        public string       Message  { get; set; }
        public bool         IsValid  { get; set;  }
    }
}
