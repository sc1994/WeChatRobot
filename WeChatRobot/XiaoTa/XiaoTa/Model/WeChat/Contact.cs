using System.Collections.Generic;

namespace Model.WeChat
{
    public class Contact
    {
        public int Uin { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string HeadImgUrl { get; set; } = string.Empty;
        public int ContactFlag { get; set; }
        public int MemberCount { get; set; }
        public List<Member> MemberList { get; set; } = new List<Member>();
        public string RemarkName { get; set; } = string.Empty;
        public int HideInputBarFlag { get; set; }
        public int Sex { get; set; }
        public string Signature { get; set; } = string.Empty;
        public int VerifyFlag { get; set; }
        public int OwnerUin { get; set; }
        // ReSharper disable once InconsistentNaming
        public string PYInitial { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string PYQuanPin { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string RemarkPYInitial { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string RemarkPYQuanPin { get; set; } = string.Empty;
        public int StarFriend { get; set; }
        public int AppAccountFlag { get; set; }
        public int Statues { get; set; }
        public int AttrStatus { get; set; }
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public int SnsFlag { get; set; }
        public int UniFriend { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public int ChatRoomId { get; set; }
        public string KeyWord { get; set; } = string.Empty;
        public string EncryChatRoomId { get; set; } = string.Empty;
        public int IsOwner { get; set; }

    }
}
