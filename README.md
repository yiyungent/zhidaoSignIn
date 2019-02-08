<h1 align="center">zhidaoSignIn</h1>

> 百度知道自动签到

[![repo size](https://img.shields.io/github/repo-size/yiyungent/zhidaoSignIn.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/zhidaoSignIn.svg?style=flat)](https://mit-license.org/)

## 简介

zhidaoSignIn 告别每天手动签到，让程序每天帮你签到

## 功能

- [x] 百度知道自动签到

## 快速搭建

1. 下载发布部署包 <a href="https://github.com/yiyungent/zhidaoSignIn/releases/download/v0.1.0/Publish.zip" target="_blank">Publish.zip</a>
2. 浏览器打开 百度知道，通过 F12 获取其中的 Cookie
3. 解压 Publish.zip，将 Publish 文件夹下的所有文件上传到 Web服务器的根目录
4. 下面以GearHost的免费虚拟主机为例 进行搭建
5. 前往 https://www.gearhost.com/ 注册账号
6. 注册完毕后，前往 https://my.gearhost.com/CloudSite 控制面板
7. 点击 右上角 Add CloudSite 新增站点
8. 输入站点名，例如：zhidaoSignIn   （添加完毕后，站点的访问网址是：http://zhidaosignin.gearhostpreview.com/ ），确保第一项Free被选中（蓝色），滑动页面到下方，点击 Create CloudSite
9. 等待 zhidaoSignIn 的 Status 变为 Running，这时站点已经正在运行
10. 点击 zhidaoSignIn 进入 配置面板
11. 点击上方 Publish 进入发布配置
12. FTP Publishing Credentials 下方的信息即为站点 FTP信息
    1. Hostname 主机名
    2. Username 用户名
    3. Password 密码
13. 使用你喜欢的 FTP上传工具（用于上传zhidaoSignIn到你的GearHost主机），这里使用 <a href="https://winscp.net/eng/docs/lang:chs" target="_blank">WinSCP</a> 
14. File protocol: FTP, Port number: 21, 其它见 Publish 中的 FTP Publishing Credentials
15. 使用 GearHost 则将 Publish.zip解压后，先将cookie信息保存到 Publish 中的 cookie.txt，再将其中的所有文件上传到 site/wwwroot 目录下
    1. 其实不需要 完整 cookie 信息，你可以保存BDUSS值到cookie.txt文件中，或则 以 BDUSS=BDUSS值; 的格式保存到 cookie.txt 中
16. 上传完毕后，访问你的预览地址 + /corn.ashx（如：http://zhidaosignin.gearhostpreview.com/corn.ashx ）, 若提示 "签到成功, 签到时间:2019-02-07 22:32:41"，则说明搭建成功，若提示检查 cookie,那么 请重新获取 cookie 并填写到 cookie.txt中
17. 现在还差一个监控程序，用于每天访问此 地址，实现每日自动签到
18. 这里使用<a href="http://cron.qqzzz.net/" target="_blank">彩虹免费监控网</a>，（其为第三方网站，请注意自己的账号密码，使用它仅因为可6小时执行一次，其它频率太高，恐百度发现签到异常）
19. 选择执行频率为 6小时的网址监控任务，网址填刚才测试访问的地址（http://zhidaosignin.gearhostpreview.com/corn.ashx）
20. 完成搭建

## 环境

- 运行环境：.NET Framework 4.5+    
- 开发环境：Visual Studio Community 2017
