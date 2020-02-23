import axios from 'axios'
import oidc from './oidc'

axios.defaults.baseURL = '/api'

//请求时的拦截
axios.interceptors.request.use(function(config){
    //发送请求之前做一些处理
    function getCookie(name) {
        if (name != null) {
       var value = new RegExp("(?:^|; )" + encodeURIComponent(String(name)) + "=([^;]*)").exec(document.cookie);
       return value ? decodeURIComponent(value[1]) : null;
       }
     }

     let token =getCookie('userId');
   
     if(token)
     {
        config.headers['authorization']='Bearer '+token
        
     }
     else 
     {
        oidc.signinRedirect();
     }
     return config;
},
    function(err){
        return Promise.reject(err)
    })


    axios.interceptors.response.use(function(res)
    {
        var httpcode=res.status;
        switch(httpcode)
        {
            case 200:break
        }
        return res;
    },
        function(err)
        {
            return Promise.reject(err)

        }
    )
export default axios