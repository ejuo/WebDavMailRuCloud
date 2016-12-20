## **WebDAV UI for Mail.ru Cloud**<br>

Based on  Console version (https://github.com/yar229/WebDavMailRuCloud)

**Requirements:**
* Microsoft .NET Framework 4.5

**Windows**

Use as Windows disk: <br>
``` 
	net use <disk>: http://127.0.0.1:<port>
``` 	

Windows 7 client might perform very bad when connecting to any WebDAV server. This is caused, because it tries to auto-detect any proxy server before any request. Refer to KB2445570 for more information.

By default, Windows limits file size to 5000000 bytes, you can increase it up to 4Gb:
* Press Win+R, type `regedit`, click OK
* HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WebClient\Parameters
* Right click on the FileSizeLimitInBytes and click Modify
* Click on Decimal
* In the Value data box, type 4294967295, and then click OK.

[Wrong disk size when mapped as Windows drive](https://support.microsoft.com/en-us/kb/2386902)<br>
Microsoft says - "It's not a bug, it's by design"

**Big thanks** to
* [Ramon de Klein](https://github.com/ramondeklein) for [nwebdav server](https://github.com/ramondeklein/nwebdav)
* [Erast Korolev](https://github.com/erastmorgan) for [Mail.Ru.net-cloud-client](https://github.com/erastmorgan/Mail.Ru-.net-cloud-client)

**Remarks**
* [How to compile for Linux](https://toster.ru/q/375448) from [Алексей Немиро](https://toster.ru/user/AlekseyNemiro) (yep, I'm lazy ass...)
* Using within [**Total Commander**](http://www.ghisler.com/) requires to update `WebDAV plugin` to [v.2.9](http://ghisler.fileburst.com/fsplugins/webdav.zip)
* Avoid using #, %, +  in file and folder names
* If you have paid account - you can remove 2Gb filesize limitation using `--user-agent "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17/TCWFX(x64)"` (taken from [pozitronik/CloudMailRu]( https://github.com/pozitronik/CloudMailRu), no any guarantees, speed limit may exist)
