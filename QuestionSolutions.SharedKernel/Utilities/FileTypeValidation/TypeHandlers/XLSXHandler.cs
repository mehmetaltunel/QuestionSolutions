using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers
{
    public class XLSXHandler : FileTypeHandler
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
                var header = new[] { "50", "4B" };

                for (int i = 0; i < 2; i++)
                {
                    if (!string.Equals(buffer[i].ToString("x2"), header[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        return new FileValidationResult
                        {
                            Message = "XLSX dosyası değil",
                            IsValid = false
                        };
                    }
                }

                return new FileValidationResult
                {
                    MimeType = new FileMimeType
                    {
                        Extension = ".xlsx",
                        Description = "Excel",
                        MimeType = "application/xlsx"
                    },
                    IsValid = true
                };
            }

            return new FileValidationResult
            {
                Message = "XLSX dosyası değil",
                IsValid = false
            };
        }
    }
}
