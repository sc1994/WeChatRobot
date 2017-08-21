using System.Collections.Generic;
using System.Xml;
using Commonality;
using Model.WeChat;

namespace HttpHelper
{
    using Model;
    using System;
    using System.Text;
    public partial class WeChatHelper
    {
        /// <summary>
        /// 登陆的临时Id
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private static string _temp_code = string.Empty;

        private static string _skey = string.Empty;

        private static string _sid = string.Empty;

        private static string _uin = string.Empty;

        private static string _pass_ticket = string.Empty;

        /// <summary>
        /// 获取登陆QR 的二维码
        /// </summary>
        /// <returns></returns>
        public static string GetLogInQrUrl()
        {
            var bytes = new WebHelper().SendGetRequest(_logIn_temp_code);
            if (bytes != null)
            {
                _temp_code = Encoding.UTF8.GetString(bytes).Split(new[] { "\"" }, StringSplitOptions.None)[1];
            }
            else
            {
                // todo 日志
            }
            return _logIn_QR_url + _temp_code;
        }

        /// <summary>
        /// 获取扫码状态
        /// </summary>
        /// <returns></returns>
        public static ScanQrState GetScanState()
        {
            if (_temp_code == string.Empty)
            {
                return ScanQrState.NotScan;
            }
            var bytes = new WebHelper().SendGetRequest(_logIn_QR_scan_state_url + _temp_code);
            string code = string.Empty;
            if (bytes != null)
            {
                code = Encoding.UTF8.GetString(bytes);
            }
            else
            {
                // todo 日志 
            }

            if (code.Contains("=201")) // 已扫描（未登录）
            {
                return ScanQrState.NotLogIn;
            }
            else if (code.Contains("=200"))
            {
                return ScanQrState.LogInWin;
            }
            else
            {
                return ScanQrState.NotScan;
            }
        }

        /// <summary>
        /// 初始化微信
        /// </summary>
        /// <returns></returns>
        public WeChatInitModel InitWechat()
        {
            var initObj = new WeChatInitModel();
            var scanBytes = new WebHelper().SendGetRequest(string.Format(_get_scan_code, _temp_code, DataHelper.GetTimeStamp(13)));
            if (scanBytes != null)
            {
                var url = scanBytes.BytesToString();
                url = url.Substring(url.IndexOf("https", StringComparison.Ordinal));
                var cookieBytes = new WebHelper().SendGetRequest(string.Format(_get_cookie_message, url));
                var cookieXml = cookieBytes.BytesToString();
                var xdoc = new XmlDocument();
                xdoc.LoadXml(cookieXml);
                var nodeList = xdoc.ChildNodes;
                var chileNode = nodeList.Item(0).ChildNodes;
                _skey            = chileNode.Item(1).NextSibling.FirstChild.InnerText;
                _sid             = chileNode.Item(2).NextSibling.FirstChild.InnerText;
                _uin          = chileNode.Item(3).NextSibling.FirstChild.InnerText;
                _pass_ticket = chileNode.Item(4).NextSibling.FirstChild.InnerText;
                var body = new
                {
                    BaseRequest = new
                    {
                        DeviceID = "e056129658814261",
                        Sid = _sid,
                        Skey = _skey,
                        Uin = _uin
                    }
                };

                var bodyStr = body.ObjectToJson();
                var initBytes = new WebHelper().SendPostRequest(string.Format(_init_wechat, _pass_ticket), bodyStr);
                initObj = initBytes.BytesToString().JsonToObject<WeChatInitModel>();
            }
            return initObj;
        }

        /// <summary>
        /// 开启wechat消息通知
        /// </summary>
        /// <param name="userName"></param>
        public static void OpenWechatInform(string userName)
        {
            var body = new
            {
                BaseRequest = new
                {
                    DeviceID = "e549616542466987",
                    Sid = _sid,
                    Skey = _skey,
                    Uin = _uin
                },
                ClientMsgId = DataHelper.GetTimeStamp(13),
                Code = 3,
                FromUserName = userName,
                ToUserName = userName
            };
            new WebHelper().SendPostRequest(_open_wechat_inform, body.ObjectToJson());
        }

        /// <summary>
        /// 获取最近聊天人员列表 todo 作为扩展
        /// </summary>
        public static void GetUserList()
        {
            new WebHelper().SendGetRequest(string.Format(_get_user_list, DataHelper.GetTimeStamp(13), _skey));
        }

        /// <summary>
        /// 请求是否有新消息
        /// </summary>
        /// <param name="listKey"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool RequestNewMessage(List<ListKey> listKey, string count)
        {
            var strKeys = string.Empty;
            foreach (var key in listKey)
            {
                strKeys += key.Key + "_" + key.Val + "|";
            }

            var bytes = new WebHelper().SendGetRequest(
                string.Format(_await_message_response,
                    _skey, _sid, _uin, strKeys.TrimEnd('|'), count), 500000);
            var msg = bytes.BytesToString();
            if (msg.Contains("2"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="sk"></param>
        /// <returns></returns>
        public static ResponseMessage GetMessage(SyncKey sk)
        {
            var body = new
            {
                BaseRequest = new
                {
                    Uin = long.Parse(_uin),
                    Sid = _sid,
                    Skey = _skey,
                    DeviceID = "e155590153985983"
                },
                SyncKey = sk,
                rr = long.Parse($"-{DataHelper.GetTimeStamp(10).Substring(0, 9).Negation()}")
            }.ObjectToJson();
            var bytes = new WebHelper().SendPostRequest(
                string.Format(_get_new_message, _sid, _skey, _pass_ticket), body);
            var response = bytes.BytesToString().JsonToObject<ResponseMessage>();
            return response;
        }

        /// <summary>
        /// 同步信息查看状态
        /// </summary>
        /// <param name="fromUser"></param>
        /// <param name="toUser"></param>
        public static void SyncMessageState(string fromUser, string toUser)
        {
            var body = new
            {
                BaseRequest = new
                {
                    Uin = long.Parse(_uin),
                    Sid = _sid,
                    Skey = _skey,
                    DeviceID = "e115422929058964"
                },
                Code = 1,
                FromUserName = fromUser,
                ToUserName = toUser,
                ClientMsgId = long.Parse(DataHelper.GetTimeStamp(13))
            }.ObjectToJson();
            var bytes = new WebHelper().SendPostRequest(
                string.Format(_open_wechat_inform, _sid, DataHelper.GetTimeStamp(13)), body);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息体</param>
        /// <param name="fromUser">发送人Id</param>
        /// <param name="toUser">接收人Id</param>
        /// <returns></returns>
        public static string SendMessage(string message, string fromUser, string toUser)
        {
            var msgId = DataHelper.GetTimeStamp(13) + DataHelper.GetRandom(4);
            var body = new
            {
                BaseRequest = new
                {
                    Uin = long.Parse(_uin),
                    Sid = _sid,
                    Skey = _skey,
                    DeviceID = "e115422929058964"
                },
                Msg = new
                {
                    Type = 1,
                    Content = message,
                    FromUserName = fromUser,
                    ToUserName = toUser,
                    LocalID = msgId,
                    ClientMsgId = msgId,
                },
                Scene = 0
            }.ObjectToJson();
            var bytes = new WebHelper().SendPostRequest(
                string.Format(_send_message, _pass_ticket), body);
            return bytes.BytesToString();
        }

    }
}
