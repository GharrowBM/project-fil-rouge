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
import {connect} from "react-redux";
import {fetchPosts} from "./store/actions/postsActions";



  class App extends React.PureComponent {
    constructor(props) {
        super(props)
    }

    componentDidMount(){
        this.props.fetchPosts();
  }

    render(){
      return (
        <Router>
            <Switch>
            <Route path="/about">
            <About />
              </Route>
              <Route path="/signin" component={() =>(<SignIn passConnectionToParent={this.passConnectionToParent}/>)}/>
              <Route path="/register" component={() =>(<Register passConnectionToParent={this.passConnectionToParent}/>)}/>
                <Route path="/question/add" component={() => (<PostQuestionForm currentUserId={this.state.currentUserId}/>)}/>
              <Route path="/question/:id" component={() =>(<QuestionDetails/>)}/>
              <Route path="/" component={() =>(<Home />)}/>
            </Switch>
        </Router>
      );
    }
  }

const mapStateToProps = (state) => {
    return {
        loading: state.postsStore.isLoading
    }
}

const mapActionToProps = (dispatch) => {
    return {
        fetchPosts: () => dispatch(fetchPosts())
    }
}



export default connect(mapStateToProps, mapActionToProps)(App)