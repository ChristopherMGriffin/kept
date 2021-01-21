import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  userProfile: {},
  userKeeps: [],
  userVaults: [],
  userVaultKeeps: [],
  activeProfile: {},
  activeKeep: [],
  activeVaults: [],
  activeVaultKeeps: [],
  allKeeps: []
})
