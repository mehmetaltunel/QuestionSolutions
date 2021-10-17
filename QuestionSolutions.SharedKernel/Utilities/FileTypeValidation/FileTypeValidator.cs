using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.TypeHandlers;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation
{
    public class FileTypeValidator
    {
        /// <summary>
        /// 
        /// </summary>
        public string Base64 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Buffer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64"></param>
        public FileTypeValidator(string base64)
        {
            Base64 = Regex  .Replace(base64, @"^.+?(;base64),", string.Empty);

            Buffer = string.IsNullOrEmpty(Base64) ? Array.Empty<byte>() : Convert.FromBase64String(Base64);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public FileTypeValidator(byte[] buffer)
        {
            Buffer = buffer ?? Array.Empty<byte>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FileValidationResult[] Handle(FileTypes fileTypes)
        {
            var _fileTypeHandlers = new List<FileTypeHandler>();

            if (fileTypes.HasFlag(FileTypes.GIF     )) _fileTypeHandlers.Add(new GIFHandler());
            if (fileTypes.HasFlag(FileTypes.PNG     )) _fileTypeHandlers.Add(new PNGHandler());            
            if (fileTypes.HasFlag(FileTypes.PDF     )) _fileTypeHandlers.Add(new PDFHandler());
            if (fileTypes.HasFlag(FileTypes.JPG_JPEG)) _fileTypeHandlers.Add(new JPGHandler());
            if (fileTypes.HasFlag(FileTypes.DOC))      _fileTypeHandlers.Add(new DOCHandler());
            if (fileTypes.HasFlag(FileTypes.TXT))      _fileTypeHandlers.Add(new TXTHandler());
            if (fileTypes.HasFlag(FileTypes.XLS))      _fileTypeHandlers.Add(new XLSHandler());
            if (fileTypes.HasFlag(FileTypes.RTF))      _fileTypeHandlers.Add(new RTFHandler());
            if (fileTypes.HasFlag(FileTypes.XLSX))     _fileTypeHandlers.Add(new XLSXHandler());

            var result = new ConcurrentBag<FileValidationResult>();

            Parallel.ForEach(_fileTypeHandlers, fileTypeHandler =>
            {
                result.Add(fileTypeHandler.Handle(Buffer));
            });

            return result.ToArray();
        }
    }
}
