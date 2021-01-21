import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'

class VaultService {
  async createVault(nv) {
    try {
      const res = await api.post('api/vaults', nv)
      logger.log('fe service', res.data)
      if (nv.corn === AppState.user.id) {
        profileService.getUserVaults(nv.corn)
        profileService.getProfileVaults(nv.corn)
      }

      profileService.getProfileVaults(nv.corn)
    } catch (e) {
      logger.log(e)
    }
  }

  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      AppState.vaults = res.data
      logger.log('ws', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      this.getVaultKeeps(id)
      AppState.activeVault = res.data
      logger.log('getOneVault', AppState.activeVault)
    } catch (e) {
      logger.log(e)
    }
  }

  async getVaultKeeps(id) {
    try {
      const res = await api.get('api/vaults/' + id + '/keeps')
      AppState.activeVaultKeeps = res.data
      logger.log('getvaultkeeps', AppState.activeVaultKeeps)
    } catch (e) {
      logger.log(e)
    }
  }

  async createVaultKeep(vId) {
    try {
      const newVk = {
        vaultId: vId,
        keepId: AppState.activeKeep.id
      }
      logger.log('w.s.1', newVk)
      const res = await api.post('api/vaultkeeps', newVk)
      logger.log('w.s.2', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async deleteVault(id) {
    try {
      window.confirm('You are about to delete vault ' + id + '. Are you sure?')
      await api.delete('api/vaults/' + id)
      profileService.getProfileVaults(AppState.activeProfile.id)
      logger.log('vault deleted')
    } catch (e) {
      logger.log(e)
    }
  }

  async deleteVaultKeep(vk) {
    try {
      window.confirm('Are you sure you want to remove ' + vk.name + ' ?')
      await api.delete('api/vaultkeeps/' + vk.vaultKeepId)
      vaultService.getVaultKeeps(AppState.activeVault.id)
      logger.log('vaultkeep deleted')
    } catch (e) {
      logger.log(e)
    }
  }
}

export const vaultService = new VaultService()
