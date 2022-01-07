import {getAllPosts} from "../../services/dataService";

export const IS_LOADING = 'IS_LOADING'
export const END_FETCHING_POSTS = 'END_FETCHING_POSTS'
export const ERROR_FETCHING_POSTS = 'ERROR_FETCHING_POSTS'
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