import React, { Component } from 'react';
import { Layout } from '../components/Layout';
import StoreDetails  from '../components/StoreDetails';
import Login from '../components/Login';
import { PrivateRoute } from '../components/PrivateRoute';
import { Router, Route } from 'react-router-dom';
import { history } from '../_helpers';
import { authenticationService } from '../_services/authenticationService';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
      super(props);

      this.state = {
          currentUser: null
      };
  }

  componentDidMount() {
      authenticationService.currentUser.subscribe(x => this.setState({ currentUser: x }));
  }

  logout() {
      authenticationService.logout();
      history.push('/login');
    }
    

    render() {
    return (
        <Layout>
            <Router history={history}>
                <Route exact path='/login' component={Login} />
                <PrivateRoute exact path="/" component={StoreDetails} />
            </Router>
        </Layout>
    );
  }
}
