namespace HttpHelper
{
    partial class WeChatHelper
    {

        /// <summary>
        /// 请求_temp_code URL
        /// </summary>
        private static string _logIn_temp_code = "https://login.weixin.qq.com/jslogin?appid=wx782c26e4c19acffb";

        /// <summary>
        /// 请求QR URL
        /// </summary>
        private static string _logIn_QR_url = "https://login.weixin.qq.com/qrcode/";

        /// <summary>
        /// 响应QR 扫描状态 URL
        /// </summary>
        private static string _logIn_QR_scan_state_url = "https://login.weixin.qq.com/cgi-bin/mmwebwx-bin/login?loginicon=true&uuid=";

        /// <summary>
        /// 获取scan的值
        ///     0：uuid
        ///     1：13位的时间戳
        /// </summary>
        private static string _get_scan_code = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/login?loginicon=true&uuid={0}&tip=0&_={1}";

        /// <summary>
        /// 获取cookie 信息 
        ///     0：_get_scan_code返回的url
        /// </summary>
        private static string _get_cookie_message = "{0}&fun=new&version=v2";

        /// <summary>
        /// 初始化
        ///     0：pass_ticket
        /// </summary>
        private static string _init_wechat = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxinit?lang=zh_CN&pass_ticket={0}";

        /// <summary>
        /// 等待信息响应的长轮询 心跳27s
        /// 参数：
        ///     0：skey
        ///     1：sid
        ///     2：uin
        ///     3：synckey
        ///     4：_ (长轮询的计数器)
        /// </summary>
        private static string _await_message_response = "https://webpush.wx2.qq.com/cgi-bin/mmwebwx-bin/synccheck?skey={0}&sid={1}&uin={2}&deviceid=e120163069283405&synckey={3}&_={4}";

        /// <summary>
        /// 打开状态通知
        /// </summary>
        private static string _open_wechat_inform = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxstatusnotify";

        /// <summary>
        /// 获取信息列表
        /// 参数：
        ///     0：十三位时间戳
        ///     1：skey
        /// </summary>
        private static string _get_user_list = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact?r={0}&seq=0&skey={1}";

        /// <summary>
        /// 获取最新的消息
        /// 参数：
        ///     0：sid
        ///     1：skey
        ///     2：pass_ticket
        /// </summary>
        private static string _get_new_message =
            "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsync?sid={0}&skey={1}&lang=zh_CN&pass_ticket={2}";

        /// <summary>
        /// 发送信息
        /// 参数：
        ///     0：pass_ticket
        /// </summary>
        private static string _send_message = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg?pass_ticket={0}&lang=zh_CN";

    }
}
