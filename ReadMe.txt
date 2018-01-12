
1. 本系统采用 纯静态页面通过ajax访问 web  api 的方式；
2. 使用Nginx作为Web 服务器和反向代理工具。
3. 为了避免ajax跨域访问限制， 我们将ajax url与静态网站url配置在同一个域下， 通过反向代理访问web  api url 接口；

