const initialState = {
    isLoading: false,
    posts: undefined,
    tags: undefined,
    error: undefined
}

export const infosReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'IS_LOADING_INFOS':
            return {
                ...state,
                isLoading: action.value
            }
            break;
        case 'END_FETCHING_INFOS':
            return {
                ...state,
                isLoading: false,
                posts: action.posts,
                tags: action.tags,
                error: undefined
            }
            break;
        case 'ERROR_FETCHING_INFOS':
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
            return {...state}
            break
    }
}