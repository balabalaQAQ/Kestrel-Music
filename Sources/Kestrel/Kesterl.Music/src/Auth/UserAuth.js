import applicationUserManager from "./applicationusermanager";
const userAuth = {
  data() {
    return {
      user: {
        name: "",
        isAuthenticated: false
      }
    };
  },
  methods: {
    async refreshUserInfo() {//获取用户信息
      const user = await applicationUserManager.getUser();
      if (user) {
        this.user.name = user.profile.name;
        this.user.isAuthenticated = true;
      } else {
        this.user.name = "";
        this.user.isAuthenticated = false;
      }
    }
  },
  async created() {
    await this.refreshUserInfo();
  }
};
export default userAuth;