import axios from 'axios'

export default function apiUrl() {
  let url = `${window.location.protocol}//${window.location.host}`
  if (url === 'http://localhost:5173') {
    url = 'http://localhost:5000/api'
  }

  return axios.create({
    baseURL: url,
  })
}
