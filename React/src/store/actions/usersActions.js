import {getAllUsers, getUser, loginUser} from "../../services/dataService";

export const IS_LOADING = 'IS_LOADING'
export const END_FETCHING_USERS = 'END_FETCHING_USERS'
export const ERROR_FETCHING_USERS = 'ERROR_FETCHING_USERS'
export const END_FETCHING_USER = 'END_FETCHING_USER'
export const ERROR_FETCHING_USER = 'ERROR_FETCHING_USER'

export const fetchUsers = () => {
    return (dispatch) => {
        dispatch({
            type : IS_LOADING,
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
            type : IS_LOADING,
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