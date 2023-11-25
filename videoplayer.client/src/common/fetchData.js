import axios from 'axios';

export function createApiInstance() {
  let url = `${window.location.protocol}//${window.location.host}`;
  if (url === 'http://localhost:5173') {
    url = 'http://localhost:5000/api';
  }

  return axios.create({
    baseURL: url,
  });
}

export async function fetchData(endpoint) {
  const api = createApiInstance();

  try {
    const response = await api.get(endpoint);
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
}
