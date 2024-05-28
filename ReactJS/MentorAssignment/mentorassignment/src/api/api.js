import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5000',
});

export const setAuthToken = (token) => {
    if (token) {
        apiClient.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    } else {
        delete apiClient.defaults.headers.common['Authorization'];
    }
};

export const fetchPostById = async (id) => {
    const response = await apiClient.get(`/posts/${id}`);
    return response.data;
};

export const updatePost = async (id, postData) => {
    const response = await apiClient.put(`/posts/${id}`, postData);
    return response.data;
};

export const createPost = async (postData) => {
    const response = await apiClient.post('/posts', postData);
    return response.data;
};

export const fetchProfile = async () => {
    const response = await apiClient.get('/profile');
    return response.data;
};

export default {
    setAuthToken,
    fetchPostById,
    updatePost,
    createPost,
    fetchProfile,
};
