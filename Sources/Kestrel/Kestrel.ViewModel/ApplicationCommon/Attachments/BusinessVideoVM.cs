
using Kestrel.EntityModel.Attachments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.ViewModels.Common
{
    public class BusinessVideoVM
    {
        public Guid Id { get; set; }
        public string ObjectId { get; set; }
        public string FileDisplayName { get; set; }
        public string FilePath { get; set; }

        public BusinessVideoVM()
        {
            this.Id = Guid.NewGuid();
        }

        public BusinessVideoVM(BusinessVideo bo)
        {
            this.Id = bo.ID;
            this.ObjectId = bo.RelevanceObjectID.ToString();
            this.FileDisplayName = bo.Name;
            this.FilePath = bo.UploadPath;
        }
    }
}
