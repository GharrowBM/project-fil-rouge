import {getAllPosts, getPost} from "../../services/dataService";

export const IS_LOADING = 'IS_LOADING'
export const END_FETCHING_POSTS = 'END_FETCHING_POSTS'
export const ERROR_FETCHING_POSTS = 'ERROR_FETCHING_POSTS'
export const END_FETCHING_POST = 'END_FETCHING_POST'
export const ERROR_FETCHING_POST = 'ERROR_FETCHING_POST'

export const fetchPosts = () => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING,
            value: true
        })
        getAllPosts().then(res => {
            console.log(res.data)
            dispatch({
                type : END_FETCHING_POSTS,
                posts: res.data
            })
        }).catch(error => {
            dispatch({
                type : ERROR_FETCHING_POSTS,
                error: error
            })
        })
    }
}

export const fetchPost = (id) => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING,
            value: true
        })
        getPost(id).then(res => {
            console.log(res.data)
            dispatch({
                type : END_FETCHING_POST,
                post: res.data
            })
        }).catch(error => {
            dispatch({
                type : ERROR_FETCHING_POST,
                error: error
            })
        })
    }
}