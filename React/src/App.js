import {
    BrowserRouter as Router,
    Switch,
    Route,
} from "react-router-dom";
import React from "react";
import Home from './containers/Home';
import './App.css';
import QuestionDetails from './containers/QuestionDetails'
import Register from './containers/Register'
import SignIn from "./containers/SignIn";
import About from "./containers/About";
import PostQuestionForm from "./containers/PostQuestionForm";
import Header from "./components/Header";


class App extends React.PureComponent {

    render() {
        return (
            <Router>
                <Header/>
                <Switch>
                    <Route path="/about" component={() => <About/>}/>
                    <Route path="/signin" component={() => (<SignIn/>)}/>
                    <Route path="/register" component={() => (<Register/>)}/>
                    <Route path="/question/add" component={() => (<PostQuestionForm/>)}/>
                    <Route path="/question/:id" component={() => (<QuestionDetails/>)}/>
                    <Route exact path="/" component={Home}/>
                </Switch>
            </Router>
        );
    }
}


export default App