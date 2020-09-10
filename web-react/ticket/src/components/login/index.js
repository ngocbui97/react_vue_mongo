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

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }
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
                iconPosition="left"
                placeholder="E-mail address"
              />
              <Form.Input
                fluid
                icon="lock"
                iconPosition="left"
                placeholder="Password"
                type="password"
              />

              <Button
                color="teal"
                fluid
                size="large"
                onClick={this.props.showLoading}
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
