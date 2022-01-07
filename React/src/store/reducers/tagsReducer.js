const initialState = {
    isLoading: false,
    tags: undefined,
    error: undefined
}

export const tagsReducer = (state = initialState, action) => {
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
                tags: action.tags,
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