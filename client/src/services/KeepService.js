import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'
import { profileService } from './ProfileService'
// import { swal } from 'sweetalert'
class KeepService {
  async createKeep(newKeep) {
    try {
      const res = await api.post('api/keeps', newKeep)
      logger.log(res.data, newKeep)
      if (newKeep.corn === AppState.user.id) {
        profileService.getUserKeeps(newKeep.corn)
        profileService.getProfileKeeps(newKeep.corn)
      }
      profileService.getProfileKeeps(newKeep.corn)
    } catch (e) {
      logger.log(e)
    }
  }

  async deleteKeep(id) {
    try {
      window.confirm('Verify Delete For Keep ' + id + '?')
      const res = await api.delete('api/keeps/' + id)
      profileService.getProfileKeeps(AppState.activeProfile.id)
      logger.log(res)
      this.getAll()
    } catch (e) {
      logger.log(e)
    }
  }

  async getAll() {
    try {
      const res = await api.get('api/keeps')
      AppState.allKeeps = res.data
    } catch (e) {
      logger.log(e)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      AppState.activeKeep = res.data
      logger.log('activeKeep', AppState.activeKeep)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const keepService = new KeepService()
