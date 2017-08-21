using System.Threading;
using System.Threading.Tasks;

namespace XiaoTa
{
    using Model;
    using System;
    using HttpHelper;
    class Program
    {
        static void Main(string[] args)
        {
            #region 获取二维码
            Console.WriteLine("登陆微信请扫描二维码：");
            var urlQr = WeChatHelper.GetLogInQrUrl();
            Console.WriteLine(urlQr);
            Console.WriteLine("在浏览器中查看...");
            #endregion

            #region 循环获取登陆信息
            Console.WriteLine("当前状态未扫描");
            WebHelper.OpenExplorer(urlQr);
            long count = 1;
            var isScanSuccess = false;
            while (!isScanSuccess)
            {
                Console.Write($"计数（{count++}）:");
                var scanStat = WeChatHelper.GetScanState();
                Console.WriteLine(scanStat.ToString());
                if (scanStat == ScanQrState.NotLogIn)
                {
                    ConsoleStyle.ConsoleStick();
                }
                if (scanStat == ScanQrState.LogInWin)
                {
                    isScanSuccess = true;
                }
            }
            Console.WriteLine("登陆成功");
            #endregion

            #region 初始化微信
            var initModel = new WeChatHelper().InitWechat();
            Console.WriteLine("初始化成功");
            #endregion

            #region 开启消息通知
            WeChatHelper.OpenWechatInform(initModel.User.UserName);
            WeChatHelper.GetUserList();
            #endregion

            count = initModel.SystemTime;
            var syncKey = initModel.SyncKey;
            Console.WriteLine("获取离线消息：");
            var offLine = WeChatHelper.GetMessage(syncKey);
            if (offLine.AddMsgCount > 0)
            {
                foreach (var msg in offLine.AddMsgList)
                {
                    Console.WriteLine($"              {msg.Content}");
                }
            }
            syncKey = offLine.SyncKey;
            while (true)
            {
                var isHaveNewMessage = false;

                Console.Write($"等待消息：计数{count + 1}   注：一般27秒一次");
                isHaveNewMessage = WeChatHelper.RequestNewMessage(syncKey.List, count++.ToString());
                Console.WriteLine(isHaveNewMessage.ToString());
                if (isHaveNewMessage)
                {
                    var response = WeChatHelper.GetMessage(syncKey);
                    syncKey = response.SyncKey; // 获取到新的key
                    Console.WriteLine("获取到的消息为：");
                    foreach (var msg in response.AddMsgList)
                    {
                        Console.WriteLine($"              {msg.Content}");
                        WeChatHelper.SyncMessageState(msg.ToUserName, msg.FromUserName);
                        WeChatHelper.SendMessage(msg.Content, msg.ToUserName, msg.FromUserName);
                        var sendBody = WeChatHelper.GetMessage(syncKey);
                        Console.WriteLine("发送的消息为：");
                        foreach (var m in sendBody.AddMsgList)
                        {
                            Console.WriteLine($"              {m.Content}");
                        }
                    }
                }
            }

            //var isHaveNewMessage = false;

            //Console.Write($"等待消息：计数{count + 1}   注：一般27秒一次");
            //isHaveNewMessage = WeChatHelper.RequestNewMessage(syncKey.List, count.ToString());
            //Console.WriteLine(isHaveNewMessage.ToString());
            //if (isHaveNewMessage)
            //{
            //    var response = WeChatHelper.GetMessage(syncKey);
            //    syncKey = response.SyncKey; // 获取到新的key
            //    //Task.Factory.StartNew(() =>
            //    //{
            //    //    WeChatHelper.RequestNewMessage(syncKey.List, count.ToString());
            //    //});
            //    Console.WriteLine("获取到的消息为：");
            //    foreach (var msg in response.AddMsgList)
            //    {
            //        Console.WriteLine($"              {msg.Content}");
            //        //Thread.Sleep(20000);
            //        //WeChatHelper.SyncMessageState(msg.ToUserName, msg.FromUserName);
            //        Console.WriteLine(WeChatHelper.SendMessage(msg.Content, msg.ToUserName, msg.FromUserName));
            //        //var sendBody = WeChatHelper.GetMessage(syncKey);
            //        Console.WriteLine("发送的消息为：");
            //        //foreach (var m in sendBody.AddMsgList)
            //        //{
            //        //    Console.WriteLine($"              {m.Content}");
            //        //}
            //    }

            //}



            // 用于等待
            Console.ReadLine();
        }
    }
}
