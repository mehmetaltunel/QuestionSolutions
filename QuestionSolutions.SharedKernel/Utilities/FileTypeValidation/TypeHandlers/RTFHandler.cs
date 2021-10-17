using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class RTFHandler : FileTypeHandler
    {
        public override FileValidationResult Handle(byte[] buffer)
        {
            if (buffer.Length >= 2)
            {
                var header = new[] { "7B", "5C", "72", "74", "66", "31" };

                for (int i = 0; i < 6; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "RTF dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension = ".rtf",
                        Description = "Rich Text Format",
                        MimeType = "application/rtf"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "RTF dosyası değil",
                IsValid = false
            };
        }
    }
}
