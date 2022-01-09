import axios from "axios"
const baseUrl = "https://localhost:5001/api"

const makeConfig = () => {
    return {
        headers: {Authorization: `Bearer ${localStorage.getItem('connectionToken')}`}
    }
}

export const getAllUsers = () => {
    return axios.get(baseUrl + '/User', makeConfig())
}

export const updateUser = (id, user) => {
    return axios.put(baseUrl + '/User/'+ id, user, makeConfig())
}

export const deleteUser = (id) => {
    return axios.delete(baseUrl + '/User/' + id, makeConfig())
}

export const getAllTags = () => {
    return axios.get(baseUrl + '/Tag')
}

export const getAllPosts = () => {
    return axios.get(baseUrl + '/Post')
}

export const searchPostWithString = (string) => {
    return axios.get( baseUrl + '/Post/search'+ string)
}

export const getPost = (id) => {
    return axios.get(baseUrl + '/Post/' + id, makeConfig())
}

export const postPost = (post) => {
    return axios.post(baseUrl + '/Post', {...post}, makeConfig())
}

export const postAnswer = (answer) => {
    console.log(answer);
    return axios.post(baseUrl + '/Answers', {...answer}, makeConfig())
}

export const postComment = (comment) => {
    return axios.post(baseUrl + '/Comments', {...comment}, makeConfig())
}

export const updatePost = (id, post) => {
    return axios.put(baseUrl + '/Post/'+ id, {...post}, makeConfig())
}

export const updateAnswer = (id, answer) => {
    return axios.put(baseUrl + '/Answers/'+ id, {...answer}, makeConfig())
}

export const updateComment = (id, comment) => {
    return axios.put(baseUrl + '/Comments/'+ id, {...comment}, makeConfig())
}

export const deletePost = (id) => {
    return axios.delete(baseUrl + '/Post/' + id, makeConfig())
}

export const registerUser = (data) => {
    return axios.post(baseUrl + '/User', data, makeConfig())
}

export const loginUser = (json) => {
    return axios.post(baseUrl + '/User/login', {...json}, makeConfig())
}
