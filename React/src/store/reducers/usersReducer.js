const initialState = {
    isLoading: false,
    users: undefined,
    user: undefined,
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
        case 'END_FETCHING_USERS':
            return {
                ...state,
                isLoading: false,
                users: action.users,
                error: undefined
            }
            break;
        case 'ERROR_FETCHING_USERS':
            return {
                ...state,
                isLoading: false,
                error: action.error
            }
            break;
            case 'END_FETCHING_USER':
                return {
                    ...state,
                    isLoading: false,
                    user: action.user,
                    error: undefined
                }
                break;
            case 'ERROR_FETCHING_USER':
                return {
                    ...state,
                    isLoading: false,
                    error: action.error
                }
                break;
        default:
            return {...initialState}
            break
    }
}