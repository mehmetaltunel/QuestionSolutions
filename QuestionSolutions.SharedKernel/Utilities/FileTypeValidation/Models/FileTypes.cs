using System;

namespace QuestionSolutions.SharedKernel.Utilities.FileTypeValidation.Models
{
    [Flags]
    public enum FileTypes
    {
        GIF      = 1,
        PNG      = 2,
        JPG_JPEG = 4,
        PDF      = 8,
        DOC      = 16,
        XLS      = 32,
        TXT      = 64,
        RTF      = 128,
        XLSX     = 256
    }
}
