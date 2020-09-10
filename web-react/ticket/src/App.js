import React from 'react';
import './App.css';
import Login from './components/login/index';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import routes from './routers';
import GlobalLoading from './components/loader';
function App() {
  return (
    <div className="App">
      <Router>
        <GlobalLoading></GlobalLoading>
        <Login />
        <Switch>
          {routes.map((route, i) => (
            <RouteWithSubRoutes key={i} {...route} />
          ))}
        </Switch>
      </Router>
    </div>
  );
}

function RouteWithSubRoutes(route) {
  return (
    <Route
      path={route.path}
      render={(props) => (
        // pass the sub-routes down to keep nesting
        <route.component {...props} routes={route.routes} />
      )}
    />
  );
}

export default App;
