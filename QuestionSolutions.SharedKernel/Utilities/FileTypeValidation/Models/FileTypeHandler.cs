namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models
{
    public abstract class FileTypeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract FileValidationResult Handle(byte[] buffer);
    }
}
