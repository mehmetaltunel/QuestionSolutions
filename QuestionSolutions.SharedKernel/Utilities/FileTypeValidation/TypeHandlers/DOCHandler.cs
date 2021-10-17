using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class DOCHandler : FileTypeHandler
    {
        public override FileValidationResult Handle(byte[] buffer)
        {
            if (buffer.Length >= 2)
            {
                var header = new[] { "D0", "CF", "11", "E0", "A1", "B1", "1A", "E1" };

                for (int i = 0; i < 8; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "DOC dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension = ".doc",
                        Description = "Word	document subheader (MS Office)",
                        MimeType = "application/doc"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "DOC dosyası değil",
                IsValid = false
            };
        }
    }
}
