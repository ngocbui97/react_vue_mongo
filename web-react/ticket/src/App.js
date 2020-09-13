import React from 'react';
import './App.css';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import routes from './routers';
import GlobalLoading from './components/loader';
import history from './common/history';

function App() {
  return (
    <div className="App ui grid container">
      <Router history={history}>
        <GlobalLoading></GlobalLoading>
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
      key={route.path}
      component={route.component}
      exact={route.exact}
      name={route.name}
      // render={(props) => (
      //   // pass the sub-routes down to keep nesting
      //   <route.component {...props} routes={route.routes} />
      // )}
    />
  );
}

export default App;
