import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import Home from './views/Home';
import './App.css';
import QuestionDetails from './views/QuestionDetails'
import Register from './views/Register'
import SignIn from "./views/SignIn";
import About from "./views/About";
import {useEffect, useState} from "react";
import {getAllPosts, getAllTags} from "./services/data";


function App() {

  const [selectedTags, setSelectedTags] = useState(undefined)
  const [availableTags, setAvailableTags] = useState(undefined)
  const [currentUser, setCurrentUser] = useState(undefined)
  const [posts, setPosts] = useState(undefined)
  const [firstLoading, setFirstLoading] = useState(true)

  useEffect(() => {
    getAllPosts().then(res => {
      setPosts([...res.data])
    })
    getAllTags().then(res => {
      setAvailableTags([...res.data])
    })
  }, [firstLoading])


  return (
    <Router>
        <Switch>
        <Route path="/about">
        <About />
          </Route>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/register">
            <Register />
          </Route>
          <Route path="/question/:id">
            <QuestionDetails />
          </Route>
          <Route path="/">
            <Home basePosts={posts} availableTags={availableTags}/>
          </Route>
        </Switch>
    </Router>
  );
}

export default App