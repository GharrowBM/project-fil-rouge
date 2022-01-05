import axios from "axios"
const baseUrl = "https://localhost:5001/api"
const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkbWluIiwiZXhwIjoxNjQxNTcwMTcyLCJpc3MiOiJtMmkiLCJhdWQiOiJtMmkifQ.ip-AVuYdjEqizo1UOK0jJgbygH0GjvQEYaS7jA5d56I"
const config = {
    headers: {Authorization: `Bearer ${token}`}
}
export const getAllUsers = () => {
    return axios.get(baseUrl + '/User')
}

export const getUser = (id) => {
    return axios.get(baseUrl + '/User/' + id)
}

export const postUser = (user) => {
    return axios.post(baseUrl + '/User', {...user})
}

export const updateUser = (id, user) => {
    return axios.put(baseUrl + '/User/'+ id, {...user})
}

export const deleteUser = (id) => {
    return axios.delete(baseUrl + '/User/' + id)
}

export const getAllTags = () => {
    return axios.get(baseUrl + '/Tag')
}

export const getTag = (id) => {
    return axios.get(baseUrl + '/User/' + id)
}

export const postTag = (tag) => {
    return axios.post(baseUrl + '/Tag', {...tag})
}

export const updateTag = (id, tag) => {
    return axios.put(baseUrl + '/Tag/'+ id, {...tag})
}

export const deleteTag = (id) => {
    return axios.delete(baseUrl + '/Tag/' + id)
}

export const getAllPosts = () => {
    return axios.get(baseUrl + '/Post', config)
}

export const getPost = (id) => {
    return axios.get(baseUrl + '/Post/' + id, config)
}

export const postPost = (post) => {
    return axios.post(baseUrl + '/Post', {...post})
}

export const updatePost = (id, post) => {
    return axios.put(baseUrl + '/Post/'+ id, {...post})
}

export const deletePost = (id) => {
    return axios.delete(baseUrl + '/Post/' + id)
}

/*export const postUserData = (data) => {
    return axios.post(baseUrl + '/User', data)
}}*/