import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import React from "react";
import Home from './views/Home';
import './App.css';
import QuestionDetails from './views/QuestionDetails'
import Register from './views/Register'
import SignIn from "./views/SignIn";
import About from "./views/About";
import PostQuestionForm from "./views/PostQuestionForm";
import Header from "./components/Header";



  class App extends React.PureComponent {
    constructor(props) {
        super(props)
    }

    render(){
      return (
        <Router>
          <Header />
            <Switch>
            <Route path="/about">
            <About />
              </Route>
              <Route path="/signin" component={() =>(<SignIn />)}/>
              <Route path="/register" component={() =>(<Register/>)}/>
                <Route path="/question/add" component={() => (<PostQuestionForm/>)}/>
              <Route path="/question/:id" component={() =>(<QuestionDetails/>)}/>
              <Route path="/" component={Home}/>
            </Switch>
        </Router>
      );
    }
  }



export default App