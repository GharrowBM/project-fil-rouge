import {getAllPosts, getAllTags, getPost, postPost, updatePost} from "../../services/dataService";

export const IS_LOADING = "IS_LOADING"
export const END_GETTING_ALL_POSTS_WITH_TAGS = "END_GETTING_ALL_POSTS_WITH_TAGS"
export const ERROR_GETTING_ALL_POSTS_WITH_TAGS = "ERROR_GETTING_ALL_POSTS_WITH_TAGS"
export const END_GETTING_POST_WITH_ID = "END_GETTING_POST_WITH_ID"
export const ERROR_GETTING_POST_WITH_ID = "ERROR_GETTING_POST_WITH_ID"
export const END_ADDING_NEW_POST = "END_ADDING_NEW_POST"
export const ERROR_ADDING_NEW_POST = "ERROR_ADDING_NEW_POST"
export const END_UPDATING_POST = "END_UPDATING_POST"
export const ERROR_UPDATING_POST = "ERROR_UPDATING_POST"

export const fetchAllPostsWithTags = () => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        getAllPosts().then(res => {
            const posts = res.data
            getAllTags().then(res => {
                dispatch({
                    type: END_GETTING_ALL_POSTS_WITH_TAGS,
                    posts: posts,
                    tags: res.data
                })
            })
        }).catch(error => {
            dispatch({
                type: ERROR_GETTING_ALL_POSTS_WITH_TAGS,
                error: error
            })
        })
    }
}

export const fetchPostWithId = (id) => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        getPost(id).then(res => {
            dispatch({
                type: END_GETTING_POST_WITH_ID,
                post: res.data
            })
        }).catch(error => {
            dispatch({
                type: ERROR_GETTING_POST_WITH_ID,
                error: error
            })
        })
    }
}

export const submitNewPost = (post) => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        postPost(post).then(res => {
            dispatch({
                type: END_ADDING_NEW_POST
            })
        }).catch(error => {
            dispatch({
                type: ERROR_ADDING_NEW_POST,
                error: error
            })
        })
    }
}

export const updatePostAction = (id, post) => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        updatePost(id, post).then(res => {
            dispatch({
                type: END_UPDATING_POST
            })
        }).catch(error => {
            dispatch({
                type: ERROR_UPDATING_POST,
                error: error
            })
        })
    }
}