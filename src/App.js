import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import Home from './views/Home';
import './App.css';
import { baseQuestions, baseTags, baseUsers } from "./datas/baseData";
import QuestionDetails from './views/QuestionDetails'
import Register from './views/Register'
import SignIn from "./views/SignIn";
import About from "./views/About";


function App() {
  return (
    <Router>
        <Switch>
        <Route path="/about">
        <About allQuestions={baseQuestions} allTags={baseTags} allUsers={baseUsers} >
          Hello World !
        </About>
          </Route>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/register">
            <Register />
          </Route>
          <Route path="/question/:id">
            <QuestionDetails questions={baseQuestions}/>
          </Route>
          <Route path="/">
            <Home baseQuestions={baseQuestions} baseTags={baseTags} baseUsers={baseUsers} />
          </Route>
        </Switch>
    </Router>
  );
}

export default App