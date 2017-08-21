using System.Collections.Generic;
using Model.WeChat;

namespace Model
{
    public class WeChatInitModel
    {
        public BaseResponse BaseResponse { get; set; } = new BaseResponse();

        public int Count;

        public List<Contact> ContactList { get; set; } = new List<Contact>();

        public SyncKey SyncKey { get; set; } = new SyncKey();

        public User User { get; set; } = new User();

        public string ChatSet { get; set; } = string.Empty;

        public string SKey { get; set; } = string.Empty;

        public long ClientVersion { get; set; }

        public long SystemTime { get; set; }

        public int GrayScale { get; set; }

        public int InviteStartCount { get; set; }

        // ReSharper disable once InconsistentNaming
        public int MPSubscribeMsgCount { get; set; }

        // ReSharper disable once InconsistentNaming
        public List<MPSubscribeMsg> MPSubscribeMsgList { get; set; } = new List<MPSubscribeMsg>();

        public int ClickReportInterval { get; set; }
    }
}
