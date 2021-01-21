<template>
  <div class="keep card mt-2 p-0">
    <div class="container p-0">
      <div>
        <img
          class="card-img"
          style="width: 100%; height: auto"
          :src="kprops.img"
          alt="Card image cap"
        >
        <div class="ml-0 mb-0 p-0 text-white card-img-overlay h-100 d-flex flex-column justify-content-end">
          <a href="#" @click="getOne(kprops.id)" class="text-white text-left" data-toggle="modal" :data-target="'#modelId' + kprops.id">

            <p class="align-self-start mb-1 ml-1">
              {{ kprops.name }}
            </p>
          </a>
          <router-link :to="{ name: 'Profile', params: { profileId: kprops.creatorId} }">
            <!-- <i class="ml-5 fa fa-user-circle bottom-right" aria-hidden="true"></i> -->
            <img
              :src="kprops.creator.picture"
              alt="user photo"
              height="15"
              class="rounded bottom-right"
            />
          </router-link>
          <p id="name" class="bottomer">
            {{ kprops.creator.name }}
          </p>
        </div>
      </div>
      <div :id="'modelId' + kprops.id"
           class="modal fade bd-example-modal-lg"
           tabindex="-1"
           role="dialog"
           aria-labelledby="myLargeModalLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-lg">
          <div class="modal-content ">
            <div class="modal-body p-2">
              <div class="container-fluid ">
                <div class="row">
                  <div class="col-5 ">
                    <div class="row">
                      <img id="modal-image" :src="kprops.img" alt="">
                    </div>
                  </div>
                  <div class="col-7">
                    <div class="row">
                      <div class="col-12">
                        <button type="button" class="close btn btn-lg" data-dismiss="modal" aria-label="Close">
                          <span class="text-danger" aria-hidden="true">&times;</span>
                        </button>
                      </div>
                    </div>
                    <div class="row">
                      <div class="pr-2 col-4 d-flex justify-content-end">
                        <p class="fade.in">
                          <i class="fas fa-eye    "></i>
                          {{ activeKeep.views }}
                        </p>
                      </div>
                      <div class="col-3">
                        <p>
                          <img class="pl-4 clr center pb-1"
                               src="../assets/img/klogo.png"
                               height="20"
                          />
                          {{ kprops.timesKept }}
                        </p>
                      </div>
                      <div class="col-3 pl-0">
                        <p class="">
                          <i class="fas fa-project-diagram"></i>
                          {{ kprops.shares }}
                        </p>
                      </div>
                    </div>
                    <div class="mb-3 header">
                      <div class="row">
                        <div class="ml-2 col-12">
                          <h1>{{ kprops.name }}</h1>
                        </div>
                      </div>
                    </div>
                    <div class="row" id="modal-description">
                      <div class="col-12">
                        <p>{{ kprops.description }}</p>
                      </div>
                    </div>

                    <div class="row border-top border-dark mt-3 justify-content-center mr-1">
                      <div class="p-1 col-12" id="tags">
                        <button class="btn btn-link">
                          tag 1
                        </button>
                        <button class="btn btn-link">
                          tag 2
                        </button>
                        <button class="btn btn-link">
                          tag 3
                        </button>
                        <button class="btn btn-link">
                          tag 4
                        </button>
                        <button class="btn btn-link">
                          tag 5
                        </button>
                        <button class="btn btn-link">
                          tag 6
                        </button>
                        <button class="btn btn-link">
                          tag 7
                        </button>
                        <button class="btn btn-link">
                          tag 8
                        </button>
                      </div>
                    </div>
                    <div id="" class="row  pl-0 justify-content-space-between">
                      <div class="col-3 pl-1">
                        <div>
                          <div class="btn-group btn-block dropup pl-0">
                            <button id="vaultdoor"
                                    type="button"
                                    class="ml-0 btn border rounded dropdown-toggle"
                                    data-toggle="dropdown"
                                    aria-haspopup="true"
                                    aria-expanded="false"
                            >
                              Add To Vault
                            </button>
                            <div class="dropdown-menu">
                              <ul class="row p-0 m-0">
                                <li class="col-12">
                                  <button type="button" class="btn btn-block btn-smbtn-link" data-toggle="modal" data-target="#modelId">
                                    Create New
                                  </button>
                                </li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col pt-2">
                        <i v-if="user.id == kprops.creatorId" id="trash" class="fas fa-trash fa-lg"></i>
                      </div>
                      <div class="col">
                        <span>
                          <img
                            :src="kprops.creator.picture"
                            alt="user photo"
                            height="40"
                            class="rounded"
                          />
                        </span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'
import { logger } from '../utils/Logger'
import { vaultService } from '../services/VaultsService'
export default {
  name: 'Keep',
  props: ['kprops', 'vprops'],
  setup(props) {
    const state = reactive({
      editedKeep: {}
    })
    return {
      state,
      profileVaults: computed(() => AppState.profileVaults),
      user: computed(() => AppState.user),
      userProfile: computed(() => AppState.userProfile),
      activeKeep: computed(() => AppState.activeKeep),
      userVaults: computed(() => AppState.userVaults),
      deleteKeep(id) {
        keepService.deleteKeep(id)
      },
      editKeep(editedKeep) {
        keepService.editKeep(editedKeep)
      },
      getOne(id) {
        keepService.getOne(id)
      },
      getActiveProfile(id) {
        profileService.getOneProfile(id)
      },
      addToVault(vId) {
        logger.log('vid', vId)
        vaultService.createVaultKeep(vId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

#modal-image {
  max-width: 20em;
  max-height: 30em;
}

i {
  color:#55efc4 ;
}
i:hover {
  transform: scale(1.5);
}

.clr {
  color:#55efc4 ;

}
#modal-description {
  max-height: 15em;
  overflow-y: auto;
}
#trash {
  color: gray;
}
#vaultdoor {
  color: #55efc4;
}
#tags {
  white-space: nowrap;
  overflow-x: auto;
  margin-bottom: 3px;
}
ul {
  list-style-type: none;
}
.bottom-right {
  position: absolute;
  bottom: 13px;
  right: 8px;
  font-size: 7;
}
#card-bottom {
  position: absolute;
  bottom: 5px;
}
.bottomer {
  position: absolute;
  bottom: -14px;
  right: 5px;
}
 #name {
   font-size: 9px;
}
.bottom-right:hover {
  transform: scale(3);
}

</style>
