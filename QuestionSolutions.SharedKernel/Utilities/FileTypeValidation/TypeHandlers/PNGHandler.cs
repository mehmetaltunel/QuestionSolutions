using System;
using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class PNGHandler : FileTypeHandler
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
                var header = new[] { "89", "50", "4E", "47", "0D", "0A", "1A", "0A" };

                for (var i = 0; i < 8; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "PNG dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType  = new FileMimeType
                    {
                        Extension   = ".png",
                        Description = "Portable Network Graphics",
                        MimeType    = "image/png"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "PNG dosyası değil",
                IsValid = false
            };
        }
    }
}
