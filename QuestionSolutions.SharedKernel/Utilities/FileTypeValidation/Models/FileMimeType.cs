using System.IO;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models
{
    public class FileMimeType
    {
        public string Extension   { get; set; }
        public string Description { get; set; }
        public string MimeType    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ValidateExtension (string path)
        {
            return string.Equals(Extension, Path.GetExtension(path));
        }
    }
}
