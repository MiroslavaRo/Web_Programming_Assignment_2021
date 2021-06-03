using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web_Programming_Assignment_2021.ViewModels
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        #region Public / Protected Properties
        public int FileSize { get; set; } = 1 * 1024 * 1024 * 1024;

        #endregion

        #region Is valid method
        public override bool IsValid(object value)
        {
           IFormFile file = value as IFormFile;
            bool isValid = true;

            int allowedFileSize = this.FileSize;

            if (file != null)
            {
                var fileSize = file.Length;

             
                isValid = fileSize <= allowedFileSize;
            }

            return isValid;
        }

        #endregion
    }
}
