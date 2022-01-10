const initialState = {
    isLoading: false,
    currentUser: undefined,
    currentUserAvatarPath: undefined,
    error: undefined
}

export const usersReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'IS_LOADING':
            return {
                ...state,
                isLoading: action.value
            }
            break;
        case 'END_REGISTER_USER':
            return {
                ...state,
                isLoading: false,
                currentUser: action.user,
                error: undefined
            }
            break;
        case 'ERROR_REGISTER_USER':
            return {
                ...state,
                isLoading: false,
                error: action.error
            }
            break;
        case 'END_LOGIN_USER':
            return {
                ...state,
                isLoading: false,
                currentUser: action.user,
                currentUserAvatarPath: action.avatarPath,
                error: undefined
            }
            break;
        case 'END_LOGOUT_USER':
            return {
                ...state,
                isLoading: false,
                currentUser: undefined,
                error: undefined
            }
            break;
        case 'ERROR_LOGIN_USER':
            return {
                ...state,
                isLoading: false,
                error: action.error
            }
            break;
        case 'END_UPDATING_USER':
            return {
                ...state,
                isLoading: false,
                currentUser: action.newUser,
                error: undefined
            }
            break;
        case 'ERROR_UPDATING_USER':
            return {
                ...state,
                isLoading: false,
                error: action.error
            }
            break;
        default:
            return {...state}
            break
    }
}