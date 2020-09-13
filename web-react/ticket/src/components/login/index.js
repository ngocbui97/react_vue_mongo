import React, { Component } from 'react';
import {
  Button,
  Form,
  Grid,
  Header,
  Message,
  Segment
} from 'semantic-ui-react';
import { withTranslation } from 'react-i18next';
import { showLoading, hideLoading } from '../../actions/ui';
import { bindActionCreators, compose } from 'redux';
import { connect } from 'react-redux';
import UserAPI from '../../api/UserApi';
import LocalStorage from '../../common/localStorage';

const localStorageService = LocalStorage.getService();

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = { Email: '', Password: '' };
  }
  onChange = (e) => {
    let target = e.target;
    let name = target.name;
    let value = target.value;
    this.setState({ [name]: value });
  };

  signIn = () => {
    UserAPI.signIn(this.state)
      .then((res) => {
        console.log(res);
        let token = {
          access_token: res.accessToken,
          refresh_token: res.refreshToken
        };
        localStorageService.setToken(token);
        this.props.history.push('/');
      })
      .catch((err) => {
        console.log(err);
      });
  };

  render() {
    const { t } = this.props;

    return (
      <Grid
        textAlign="center"
        style={{ height: '100vh' }}
        verticalAlign="middle"
      >
        <Grid.Column style={{ maxWidth: 450 }}>
          <Header as="h2" color="teal" textAlign="center">
            {t('LoginScreen.Login')} to your account
          </Header>
          <Form size="large">
            <Segment stacked>
              <Form.Input
                fluid
                icon="user"
                name="Email"
                iconPosition="left"
                placeholder="E-mail address"
                onChange={this.onChange}
              />
              <Form.Input
                fluid
                icon="lock"
                iconPosition="left"
                name="Password"
                placeholder="Password"
                type="password"
                onChange={this.onChange}
              />

              <Button
                color="teal"
                fluid
                size="large"
                onClick={() => this.signIn()}
              >
                Login
              </Button>
            </Segment>
          </Form>
          <Message>
            New to us? <a href="https://www.freeimages.com/fr">Sign Up</a>
          </Message>
        </Grid.Column>
      </Grid>
    );
  }
}

const mapDispathToProps = (dispatch) => {
  return bindActionCreators({ showLoading, hideLoading }, dispatch);
};

const withMap = connect(null, mapDispathToProps);

export default compose(withTranslation(), withMap)(Login);
