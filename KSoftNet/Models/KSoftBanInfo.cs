﻿using System;

namespace KSoftNet.Models {
    public class KSoftBanInfo {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public string ModeratorId { get; set; }
        public string Reason { get; set; }
        public string Proof { get; set; }
        public bool IsBanActive { get; set; }
        public bool CanBeAppealed { get; set; }
        public DateTime Timestamp { get; set; }
        public string AppealReason { get; set; }
        public object AppealDate { get; set; }
        public string RequestedBy { get; set; }
        public bool Exists { get; set; }

        // Error
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}