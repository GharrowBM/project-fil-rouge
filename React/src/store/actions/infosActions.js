import {getAllPosts, getAllTags, getPost} from "../../services/dataService";

export const IS_LOADING_INFOS = 'IS_LOADING_INFOS'
export const END_FETCHING_INFOS = 'END_FETCHING_INFOS'
export const ERROR_FETCHING_INFOS = 'ERROR_FETCHING_INFOS'

export const IS_LOADING_POST = 'IS_LOADING_POST'
export const END_FETCHING_POST = 'END_FETCHING_POST'
export const ERROR_FETCHING_POST = 'ERROR_FETCHING_POST'

export const fetchInfos = () => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING_INFOS,
            value: true
        })
        getAllPosts().then(res => {
            console.log(res.data)
            const posts = res.data;

            getAllTags().then(res => {
                const tags = res.data;
                dispatch({
                    type: END_FETCHING_INFOS,
                    posts: posts,
                    tags: tags
                })
            })

        }).catch(error => {
            dispatch({
                type : ERROR_FETCHING_INFOS,
                error: error
            })
        })
    }
}

export const fetchPost = (id) => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING_POST,
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


