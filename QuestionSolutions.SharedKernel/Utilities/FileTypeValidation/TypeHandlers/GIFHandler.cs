using System;
using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class GIFHandler : FileTypeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public override FileValidationResult Handle(byte[] buffer)
        {
            if (buffer.Length >= 4)
            {
                var header = new[] { "47", "49", "46", "38" };

                for (var i = 0; i < 4; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "GIF dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType  = new FileMimeType
                    {
                        Extension   = ".gif",
                        Description = "Graphics Interchange Format (GIF)",
                        MimeType    = "image/gif"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "GIF dosyası değil",
                IsValid = false
            };
        }
    }
}
