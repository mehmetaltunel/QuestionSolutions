using System;
using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class PDFHandler : FileTypeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public override FileValidationResult Handle(byte[] buffer)
        {
            if(buffer.Length >=2)
            {
                var header = new[] { "25", "50", "44", "46", "2D" };
                 
                for(int i = 0; i < 5; i++)
                {
                    if(!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "PDF dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension   = ".pdf",
                        Description = "Portable Document Format",
                        MimeType    = "application/pdf"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "PDF dosyası değil",
                IsValid = false
            };
        }
    }
}
