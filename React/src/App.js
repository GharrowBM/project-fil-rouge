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
import AccountDetails from "./containers/AccountDetails";


class App extends React.PureComponent {

    render() {
        return (
            <Router>
                <Header/>
                <Switch>
                    <Route path="/signin" component={() => (<SignIn className="signIn"/>)}/>
                    <Route path="/register" component={() => (<Register className="register" />)}/>
                    <Route path="/question/add" component={() => (<PostQuestionForm className="postQuestionForm"/>)}/>
                    <Route path="/question/:id" component={() => (<QuestionDetails className="questionDetails"/>)}/>
                    <Route path="/accountdetails" component={() => <AccountDetails className="accountDetails" />}/>
                    <Route exact path="/" component={() => <Home className="home" />}/>
                </Switch>
                <About />
            </Router>
        );
    }
}


export default App