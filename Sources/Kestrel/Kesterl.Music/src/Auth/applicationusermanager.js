import { UserManager } from 'oidc-client'

class ApplicationUserManager extends UserManager {
  constructor () {
    super({
      authority: 'http://localhost:5000',// 授权服务中心地址
      client_id: 'blogvuejs',// 客户端 id
      redirect_uri: 'http://localhost:6688/callback',// 登录回调地址
      response_type: 'id_token token',
      scope: 'openid profile roles blog.core.api',// 作用域也要一一匹配
      post_logout_redirect_uri: 'http://localhost:6688' //登出后回调地址
    })
  }

  async login () {
    await this.signinRedirect()
    return this.getUser()
  }

  async logout () {
    return this.signoutRedirect()
  }
}