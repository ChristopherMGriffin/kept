<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-primary row justify-content-between">
    <div class="col-1 pl-1">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center p-sm-0">
          <img
            alt="logo"
            src="../assets/img/klogo.png"
            height="45"
          />
        </div>
      </router-link>
    </div>
    <div class="col-9 p-0 d-flex justify-content-center">
      <!-- <div class="row"> -->
      <div class="input-group s-bar m-0">
        <input class="form-control m-auto py-2 rounded" type="search" value="search" id="example-search-input">
        <span class="input-group-append">
          <button class="btn left" type="button">
            <i class="fa fa-search"></i>
          </button>
        </span>
      </div>
      <!-- </div> -->
      <!-- <div class="form-group m-auto s-bar">
        <span class="fa fa-search form-control-feedback m-lens my-auto"></span>
        <input type="text" class="form-control">
      </div> -->
    </div>
    <div class="col-1 d-flex justify-content-end">
      <button
        class="navbar-toggler border-secondary"
        type="button"
        data-toggle="collapse"
        data-target="#navbarText"
        aria-controls="navbarText"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon" />
      </button>
      <div class="collapse navbar-collapse" id="navbarText">
        <!-- <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link :to="{ name: 'Home' }" class="nav-link">
            Home
          </router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{ name: 'About' }" class="nav-link">
            About
          </router-link>
        </li>
      </ul> -->
        <span class="navbar-text ">
          <button
            class="btn btn-outline-primary text-uppercase"
            @click="login"
            v-if="!user.isAuthenticated"
          >
            Login
          </button>

          <div class="dropdown" v-else>
            <div
              class="dropdown-toggle text-secondary"
              @click="state.dropOpen = !state.dropOpen"
            >
              <img
                :src="userProfile.picture"
                alt="user photo"
                height="40"
                class="rounded"
              />
              <span class="mx-3 text-secondary">{{ userProfile.name }}</span>
            </div>
            <div
              class="dropdown-menu py-0 mr-1 list-group w-100"
              :class="{ show: state.dropOpen }"
              @click="state.dropOpen = false"
            >
              <router-link :to="{ name: 'Profile' }">
                <div class="list-group-item list-group-item-action hoverable">
                  Profile
                </div>
              </router-link>
              <div
                class="list-group-item list-group-item-action hoverable"
                @click="logout"
              >
                logout
              </div>
            </div>
          </div>
        </span>
      </div>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      userProfile: computed(() => AppState.userProfile),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}
.s-bar{
  max-width: 70%;
  position: relative;
  left: -5%;
}
.left{
  position: absolute;
  right: .05%
}
i{
  color: #636e72;
}

</style>
