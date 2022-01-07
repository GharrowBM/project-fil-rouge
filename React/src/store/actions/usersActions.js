import {loginUser, registerUser} from "../../services/dataService";

export const IS_LOADING = "IS_LOADING"
export const END_REGISTER_USER = "END_REGISTER_USER"
export const ERROR_REGISTER_USER = "ERROR_REGISTER_USER"
export const END_LOGIN_USER = "END_LOGIN_USER"
export const ERROR_LOGIN_USER = "ERROR_LOGIN_USER"

export const loginUserAction = (json) => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        loginUser(json).then(res => {
            dispatch({
                type: END_LOGIN_USER,
                user: res.data.user
            })
        }).catch(error => {
            dispatch({
                type: ERROR_LOGIN_USER,
                error: error
            })
        })
    }
}

export const registerUserAction = (data) => {
    return (dispatch) => {
        dispatch({
            type: IS_LOADING,
            value: true
        })
        registerUser(data).then(res => {
            dispatch({
                type: END_REGISTER_USER,
                user: res.data.user
            })
        }).catch(error => {
            dispatch({
                type: ERROR_REGISTER_USER,
                error: error
            })
        })
    }
}