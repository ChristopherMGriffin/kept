import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getUserProfile() {
    try {
      const res = await api.get('api/profiles')
      AppState.userProfile = res.data
      logger.log(AppState.userProfile)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const profileService = new ProfileService()
