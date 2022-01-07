import {getAllUsers, getUser, loginUser, postUserData} from "../../services/dataService";

export const IS_LOADING_USERS = 'IS_LOADING_USERS'
export const END_FETCHING_USERS = 'END_FETCHING_USERS'
export const ERROR_FETCHING_USERS = 'ERROR_FETCHING_USERS'

export const IS_LOADING_USER = 'IS_LOADING_USER'
export const END_FETCHING_USER = 'END_FETCHING_USER'
export const ERROR_FETCHING_USER = 'ERROR_FETCHING_USER'

export const IS_REGISTERING = 'IS_REGISTERING'
export const END_REGISTERING_USER = 'END_REGISTERING_USER'
export const ERROR_REGISTERING_USER = 'ERROR_REGISTERING_USER'

export const fetchUsers = () => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING_USERS,
            value: true
        })
        getAllUsers().then(res => {
            console.log(res.data)
            dispatch({
                type : END_FETCHING_USERS,
                users: res.data
            })
        }).catch(error => {
            dispatch({
                type : ERROR_FETCHING_USERS,
                error: error
            })
        })
    }
}

export const loginUserAction = (credentials) => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING_USER,
            value: true
        })
        loginUser(credentials).then(res => {
            console.log(res.data)
            dispatch({
                type : END_FETCHING_USER,
                user: res.data.user
            })
        }).catch(error => {
            dispatch({
                type : ERROR_FETCHING_USER,
                error: error
            })
        })
    }
}

export const registerUserAction = (data) => {
    return (dispatch) => {
        dispatch({
            type : IS_REGISTERING,
            value: true
        })
        postUserData(data).then(res => {
            console.log(res.data)
            dispatch({
                type : END_REGISTERING_USER,
                user: res.data.user
            })
        }).catch(error => {
            dispatch({
                type : ERROR_REGISTERING_USER,
                error: error
            })
        })
    }
}