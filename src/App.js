import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Home from './views/Home';
import './App.css';
import { baseForums, baseTags, baseUsers } from "./datas/baseData";

function App() {
  return (
    <Router>
        <Switch>
          <Route path="/about">
          </Route>
          <Route path="/users">
          </Route>
          <Route path="/">
            <Home baseForums={baseForums} baseTags={baseTags} baseUsers={baseUsers} />
          </Route>
        </Switch>
    </Router>
  );
}

export default App