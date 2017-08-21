using System.Collections.Generic;

namespace Model.WeChat
{
    public class ResponseMessage
    {
        public BaseResponse BaseResponse { get; set; } = new BaseResponse();

        public int AddMsgCount { get; set; }

        public List<AddMsg> AddMsgList { get; set; } = new List<AddMsg>();

        public int ModContactCount { get; set; }

        public List<ModContact> ModContactList { get; set; } = new List<ModContact>();

        public int DelContactCount { get; set; }

        public List<DelContact> DelContactList { get; set; } = new List<DelContact>();

        public int ModChatRoomMemberCount { get; set; }

        public List<ModChatRoomMember> ModChatRoomMemberList { get; set; } = new List<ModChatRoomMember>();

        public Profile Profile { get; set; } = new Profile();

        public int ContinueFlag { get; set; }

        public SyncKey SyncKey { get; set; } = new SyncKey();

        public string SKey { get; set; } = string.Empty;

        public SyncKey SyncCheckKey { get; set; } = new SyncKey();
    }
}
