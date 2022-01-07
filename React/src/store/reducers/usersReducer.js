const initialState = {
    isLoading: false,
    users: undefined,
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
        case 'END_FETCHING_DATA':
            return {
                ...state,
                isLoading: false,
                users: action.users,
                error: undefined
            }
            break;
        case 'ERROR_FETCHING_DATA':
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