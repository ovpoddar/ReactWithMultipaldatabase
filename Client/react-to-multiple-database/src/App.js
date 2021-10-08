import {Layout} from './Components/Layout';
import Home  from './Components/Home';
import Create from "./Components/Create";
import { Route } from 'react-router';

function App() {
  return (
    <Layout>
        <Route exact path="/" component={Home}></Route>
        <Route exact path="/Add" component={Create}></Route>
    </Layout>
  );
}

export default App;
