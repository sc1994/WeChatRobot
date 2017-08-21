namespace Model.WeChat
{
    public class User
    {
        public long Uin { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string HeadImgUrl { get; set; } = string.Empty;
        public string RemarkName { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string PYInitial { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string PYQuanPin { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string RemarkPYInitial { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
        public string RemarkPYQuanPin { get; set; } = string.Empty;
        public int HideInputBarFlag { get; set; }
        public int StarFriend { get; set; }
        public int Sex { get; set; }
        public string Signature { get; set; } = string.Empty;
        public int AppAccountFlag { get; set; }
        public int VerifyFlag { get; set; }
        public int ContactFlag { get; set; }
        public int WebWxPluginSwitch { get; set; }
        public int HeadImgFlag { get; set; }
        public int SnsFlag { get; set; }
    }
}
