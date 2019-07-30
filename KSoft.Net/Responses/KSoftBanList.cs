using System;
using System.Collections.Generic;

namespace KSoft.Net.Responses
{
    public class KSoftBanListData
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public object ModeratorId { get; set; }
        public string Reason { get; set; }
        public string Proof { get; set; }
        public bool IsBanActive { get; set; }
        public bool CanBeAppealed { get; set; }
        public DateTime Timestamp { get; set; }
        public object AppealReason { get; set; }
        public object AppealDate { get; set; }
    }

    public class KSoftBanList
    {
        public int BanCount { get; set; }
        public int PageCount { get; set; }
        public int PerPage { get; set; }
        public int Page { get; set; }
        public int OnPage { get; set; }
        public int NextPage { get; set; }
        public object PreviousPage { get; set; }
        public IList<KSoftBanListData> Data { get; set; }

        // Error
        public bool Error { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}