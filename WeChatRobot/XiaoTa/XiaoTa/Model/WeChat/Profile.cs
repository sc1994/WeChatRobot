namespace Model.WeChat
{
    public class Profile
    {
        public int BitFlag { get; set; }
        public UserName UserName { get; set; } = new UserName();
        public NickName NickName { get; set; } = new NickName();
        public int BindUin { get; set; }
        public BindEmail BindEmail { get; set; } = new BindEmail();
        public BindMobile BindMobile { get; set; } = new BindMobile();
        public int Status { get; set; }
        public int Sex { get; set; }
        public int PersonalCard { get; set; }
        public string Alias { get; set; } = string.Empty;
        public int HeadImgUpdateFlag { get; set; }
        public string HeadImgUrl { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;

    }
}
