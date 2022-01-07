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
import {getAllPosts, getAllTags} from "./services/data";
import PostQuestionForm from "./views/PostQuestionForm";



  class App extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            selectedTags: undefined,
            availableTags: undefined,
            currentUserId: undefined,
            posts: undefined,
            isLoggedIn: false,
            token: undefined
        }
    }

    passConnectionToParent = (token, isLoggedIn, userID) => {
        this.setState({token: token, isLoggedIn: isLoggedIn, currentUserId: userID})
      }

      passPostToParent = (post) => {
        this.setState({currentPost: post})
      }


    componentDidMount(){
      getAllPosts().then(res => {
      const posts = res.data;

      console.log(posts)
      getAllTags().then(res => {
        this.setState({availableTags: [...res.data], posts: [...posts] })
      })
    })
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
              <Route path="/" component={() =>(<Home basePosts={this.state.posts} availableTags={this.state.availableTags} isLoggedIn={this.state.isLoggedIn}/>)}/>
            </Switch>
        </Router>
      );
    }
    
  }


export default App