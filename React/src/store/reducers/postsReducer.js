const initialState = {
    isLoading: false,
    posts: undefined,
    error: undefined
}

export const postsReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'IS_LOADING':
            return {
                ...state,
                isLoading: action.value
            }
            break;
        case 'END_FETCHING_POSTS':
            return {
                ...state,
                isLoading: false,
                posts: action.posts,
                error: undefined
            }
            break;
        case 'ERROR_FETCHING_POSTS':
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