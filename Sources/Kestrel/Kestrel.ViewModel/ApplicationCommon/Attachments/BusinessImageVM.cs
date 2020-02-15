
using Kestrel.EntityModel.Attachments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.ViewModels.Common
{
    public class BusinessImageVM
    {
        public Guid Id { get; set; }
        public string ObjectId { get; set; }
        public string FileDisplayName { get; set; }
        public string FilePath { get; set; }

        public BusinessImageVM()
        {
            this.Id = Guid.NewGuid();
        }

        public BusinessImageVM(BusinessImage bo)
        {
            this.Id = bo.ID;
            this.ObjectId = bo.RelevanceObjectID.ToString();
            this.FileDisplayName = bo.Name;
            this.FilePath = bo.UploadPath;
        }
    }
}
