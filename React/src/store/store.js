import { combineReducers, createStore, compose, applyMiddleware } from "redux";
import thunk from "redux-thunk"
import {usersReducer} from "./reducers/usersReducer";
import { infosReducer } from "./reducers/infosReducer";

export default createStore(
    combineReducers({
        usersStore: usersReducer,
        infosStore: infosReducer
    }),
    compose(applyMiddleware(thunk), window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())
)