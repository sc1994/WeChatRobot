// 登陆以后的时间来源
    
    /*1.
        https://wx2.qq.com/cgi-bin/mmwebwx-bin/login?loginicon=true&uuid=IaC6gYw9xA==&tip=0&r=-1099915386&_=1487158580864
        返回：
            window.code=200;window.redirect_uri="https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxnewloginpage?ticket=A-zJgALXJFv9OEuXMFcpR-vx@qrticket_0&uuid=IaC6gYw9xA==&lang=zh_CN&scan=1487158599";
    */

    /*2. cookie--???
        https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxnewloginpage?ticket=A-zJgALXJFv9OEuXMFcpR-vx@qrticket_0&uuid=IaC6gYw9xA==&lang=zh_CN&scan=1487158599&fun=new&version=v2
        返回：
             <error>
                <ret>0</ret>
                <message></message>
                <skey>@crypt_dc473b8b_793ecf026ceff65864af114caa0fb5ba</skey>
                <wxsid>7aMGpIm5Svmkmi9Z</wxsid>
                <wxuin>2656451315</wxuin>
                <pass_ticket>j%2BLSa52fsDT6yNLD9lr4qIshTppWxIdbWY5CnzMNYAcnNFBj8IGV0UqP47xMuYk%2F</pass_ticket>
                <isgrayscale>1</isgrayscale>
             </error>   
    */

    /*3. 初始化
        https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxinit?r=-1098732357
        post：BaseRequest = {
                DeviceID:"e056129658814261"
                Sid:"KOashyGa/2lBKSI8"
                Skey:""
                Uin:"xuin=2656451315"
                }
        返回：
            1.ContactList 用户列表
            2.SyncKey 同步的key 下一次请求是否有最新信息的时候需要带上这个Key（第一次是4个，以后每次是11个）
            3.User:{Uin:"",UserName:"",NickName:""......}  // NickName是昵称
            4.SKey：@crypt_dc473b8b_793ecf026ceff65864af114caa0fb5ba
            5.SystemTime:1487158603  时间戳 往后的同步请求以此加1
    */

    /*4.等待信息响应的长轮询 心跳27s
        https://webpush.wx2.qq.com/cgi-bin/mmwebwx-bin/synccheck
            ?r=1487160315375
            &skey=@crypt_dc473b8b_793ecf026ceff65864af114caa0fb5ba
            &sid=7aMGpIm5Svmkmi9Z
            &uin=2656451315
            &deviceid=e120163069283405
            &synckey=1_665644974
                    |2_665645017
                    |3_665644985
                    |11_665644505
                    |13_665620205
                    |201_1487160313
                    |1000_1487153817
                    |1001_1487154091
                    |1002_1486813638
                    |1003_1486974463
                    |1004_1484916847
            &_=1487158580959
    */
    //https://webpush.wx2.qq.com/cgi-bin/mmwebwx-bin/synccheck?skey=@crypt_dc473b8b_30864b257c0d6e291d742c74fa0a6d41&sid=iykxnGx8ubUu4MGg&uin=2656451315&deviceid=e120163069283405&synckey=1_6656452252_6656452973_6656450471000_0&_=1487248746"

    /*5.接受信息
        https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsync
            ?sid=7aMGpIm5Svmkmi9Z
            &skey=@crypt_dc473b8b_793ecf026ceff65864af114caa0fb5ba
            &lang=zh_CN
            &pass_ticket=j%2BLSa52fsDT6yNLD9lr4qIshTppWxIdbWY5CnzMNYAcnNFBj8IGV0UqP47xMuYk%2F
        post：BaseRequest = {
                DeviceID:"e056129658814261"
                Sid:"KOashyGa/2lBKSI8"
                Skey:"@crypt_dc473b8b_793ecf026ceff65864af114caa0fb5ba"
                Uin:2656451315
              },
              SyncKey:{
                  Count:,
                  List:[{
                     Key: 1, Val: 665644974 
                  },
                  {
                      .....
                  },....]
              },
              rr:-1100797328
         响应：AddMsgList:[{
             Content:"这是消息体", 
             FromUserName:"@8c1b40ad5a998be5aa3be9660f06f5aa504da7835c2d5062fe36ffef37abe783", // 谁发 的
             ToUserName：@f896640332244d5989ccea84d79772d49f6d1d0a63cca92f84a25899a2eac602
             MsgId:"5073377934259074663", // 不知道这个和下面的是干嘛的
             NewMsgId:5073377934259075000
         }]
    */


    window.synccheck={retcode:"0",selector:"7"}





