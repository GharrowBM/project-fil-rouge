import axios from "axios"
const baseUrl = "https://localhost:5001/api"
const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkbWluIiwiZXhwIjoxNjQxNTcwMTcyLCJpc3MiOiJtMmkiLCJhdWQiOiJtMmkifQ.ip-AVuYdjEqizo1UOK0jJgbygH0GjvQEYaS7jA5d56I"
const config = {
    headers: {Authorization: `Bearer ${token}`}
}
export const getAllUsers = () => {
    return axios.get(baseUrl + '/User', config)
}

export const getUser = (id) => {
    return axios.get(baseUrl + '/User/' + id, config)
}

export const postUser = (user) => {
    return axios.post(baseUrl + '/User', {...user})
}

export const updateUser = (id, user) => {
    return axios.put(baseUrl + '/User/'+ id, user, config)
}

export const deleteUser = (id) => {
    return axios.delete(baseUrl + '/User/' + id, config)
}

export const getAllTags = () => {
    return axios.get(baseUrl + '/Tag')
}

export const getTag = (id) => {
    return axios.get(baseUrl + '/User/' + id, config)
}

export const postTag = (tag) => {
    return axios.post(baseUrl + '/Tag', {...tag}, config)
}

export const updateTag = (id, tag) => {
    return axios.put(baseUrl + '/Tag/'+ id, {...tag}, config)
}

export const deleteTag = (id) => {
    return axios.delete(baseUrl + '/Tag/' + id, config)
}

export const getAllPosts = () => {
    return axios.get(baseUrl + '/Post')
}

export const searchPostWithString = (string) => {
    return axios.get( baseUrl + '/Post/search'+ string)
}

export const getPost = (id) => {
    return axios.get(baseUrl + '/Post/' + id, config)
}

export const postPost = (post) => {
    return axios.post(baseUrl + '/Post', {...post}, config)
}

export const updatePost = (id, post) => {
    return axios.put(baseUrl + '/Post/'+ id, {...post}, config)
}

export const deletePost = (id) => {
    return axios.delete(baseUrl + '/Post/' + id, config)
}

export const registerUser = (data) => {
    return axios.post(baseUrl + '/User', data, config)
}

export const loginUser = (json) => {
    return axios.post(baseUrl + '/User/login', {...json}, config)
}