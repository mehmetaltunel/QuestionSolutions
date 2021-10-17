using System;
using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class JPGHandler : FileTypeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public override FileValidationResult Handle(byte[] buffer)
        {
            if (buffer.Length >= 2)
            {
                var header = new[] { "FF", "D8" };

                for (var i = 0; i < 2; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "JPG/JPEG dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension   = ".jpg",
                        Description = "Joint Photographic Experts Group",
                        MimeType    = "image/jpeg"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "JPG/JPEG dosyası değil",
                IsValid = false
            };
        }
    }
}
