using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class XLSHandler : FileTypeHandler
    {
        public override FileValidationResult Handle(byte[] buffer)
        {
            if (buffer.Length >= 2)
            {
                var header = new[] { "PD", "FF", "FF", "FF" };

                for (int i = 0; i < 4; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "XLS dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension = ".xls",
                        Description = "Exce spreadsheet	subheade",
                        MimeType = "application/xls"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "XLS dosyası değil",
                IsValid = false
            };
        }
    }
}
