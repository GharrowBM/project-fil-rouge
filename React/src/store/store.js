import { combineReducers, createStore, compose, applyMiddleware } from "redux";
import thunk from "redux-thunk"
import {postsReducer} from "./reducers/postsReducer";
import {usersReducer} from "./reducers/usersReducer";
import {tagsReducer} from "./reducers/tagsReducer";

export default createStore(
    combineReducers({
        postsStore: postsReducer,
        usersStore: usersReducer,
        tagsStore: tagsReducer
    }),
    compose(applyMiddleware(thunk), window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())
)