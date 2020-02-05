using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Attachments
{
    public class BusinessVideo : Entity
    {
        public DateTime AttachmentTimeUploaded { get; set; }
        [StringLength(500)]
        public string OriginalFileName { get; set; }
        [StringLength(500)]
        public string UploadPath { get; set; }
        public bool IsInDB { get; set; }
        [StringLength(10)]
        public string UploadFileSuffix { get; set; }
        public byte[] BinaryContent { get; set; }
        public long FileSize { get; set; }
        [StringLength(120)]
        public string IconString { get; set; }
        public bool IsUnique { get; set; }           // 是否是唯一的，这是相对 RelevanceObjectID 来说的，如果是，在持久化的时候需要单独处理

        public Guid RelevanceObjectID { get; set; }
        public Guid UploaderID { get; set; }         // 关联上传人ID

        public BusinessVideo()
        {
            this.ID = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<BusinessVideo>();
            this.AttachmentTimeUploaded = DateTime.Now;
        }
    }
}
