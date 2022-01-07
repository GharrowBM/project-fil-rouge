const initialState = {
    isLoading: false,
    posts: undefined,
    post: undefined,
    error: undefined
}

export const postsReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'IS_LOADING_POSTS':
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
        case 'END_FETCHING_POST':
            return {
                ...state,
                isLoading: false,
                post: action.post,
                error: undefined
            }
        case 'ERROR_FETCHING_POST':
            return {
                ...state,
                isLoading: false,
                error: action.error
            }
        default:
            return {...initialState}
            break
    }
}