<template>
  <div >
22222222
  </div>
</template>
<script>

import Oidc from "oidc-client"; 

  new Oidc.UserManager()

    .signinRedirectCallback()

    .then(function (user) {
    console.log(user)
     window.location = "/" ;
 
    })

  export default {}
</script>

 