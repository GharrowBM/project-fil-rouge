import {combineReducers, createStore, compose, applyMiddleware} from "redux";
import thunk from "redux-thunk"
import {usersReducer} from "./reducers/usersReducer";
import {postsReducer} from "./reducers/postsReducer";
import {tagsReducer} from "./reducers/tagsReducer";

export default createStore(
    combineReducers({
        users: usersReducer,
        posts: postsReducer,
        tags: tagsReducer
    }),
    compose(applyMiddleware(thunk), window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())
)