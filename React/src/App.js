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



  class App extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            selectedTags: undefined,
            availableTags: undefined,
            currentUser: undefined,
            posts: undefined,
            isLoggedIn: false,
            token: undefined,
        }
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
              <Route path="/signin" component={() =>(<SignIn isLoggedIn={this.state.isLoggedIn} token={this.state.token}/>)}>

              </Route>
              <Route path="/register" component={() =>(<Register isLoggedIn={this.state.isLoggedIn} token={this.state.token}/>)}>

              </Route>
              <Route path="/question/:id" component={() =>(<QuestionDetails post={{}}/>)}>

              </Route>
              <Route path="/" component={() =>(<Home basePosts={this.state.posts} availableTags={this.state.availableTags}/>)}>
                
              </Route>
            </Switch>
        </Router>
      );
    }
    
  }


export default App