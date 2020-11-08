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
import { withFormik, Form as FormFormik, Field as FieldFormik } from 'formik';
import * as yup from 'yup';

const localStorageService = LocalStorage.getService();

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = { email: '', password: '' };
  }
  onChange = (e) => {
    let target = e.target;
    let name = target.name;
    let value = target.value;
    this.setState({ [name]: value });
  };

  signIn = () => {
    let param = {};
    param.email = this.props.values.email;
    param.password = this.props.values.password;

    console.log(this.props);
    // UserAPI.signIn(this.state)
    //   .then((res) => {
    //     console.log(res);
    //     let token = {
    //       access_token: res.accessToken,
    //       refresh_token: res.refreshToken
    //     };
    //     localStorageService.setToken(token);
    //     this.props.history.push('/');
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });
  };

  render() {
    const { t } = this.props;

    return (
      <Grid
        textAlign="center"
        style={{ height: '100vh' }}
        verticalAlign="middle"
      >
        <Grid.Column className="twelve wide column" style={{ maxWidth: 450 }}>
          <Header as="h2" color="teal" textAlign="center">
            {t('LoginScreen.Login')} to your account
          </Header>
          <FormFormik className="large form ui">
            <Segment stacked>
              <Form.Input
                fluid
                icon="user"
                name="email"
                value={this.props.values.email}
                iconPosition="left"
                placeholder="E-mail address"
                onChange={this.props.handleChange}
                onBlur={this.props.handleBlur}
                error={
                  this.props.touched.email && {
                    content: this.props.errors.email,
                    pointing: 'above'
                  }
                }
              />
              <FieldFormik name="password">
                {({
                  field, // { name, value, onChange, onBlur }
                  form: { touched, errors }, // also values, setXXXX, handleXXXX, dirty, isValid, status, etc.
                  meta
                }) => (
                  <Form.Input
                    fluid
                    icon="lock"
                    iconPosition="left"
                    placeholder="Password"
                    type="password"
                    {...field}
                    error={
                      touched.password && {
                        content: errors.password,
                        pointing: 'above'
                      }
                    }
                  />
                )}
              </FieldFormik>
              <Button
                color="teal"
                fluid
                size="large"
                type="submit"
                onClick={() => this.signIn()}
              >
                Login
              </Button>
            </Segment>
          </FormFormik>
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

const formikForm = withFormik({
  mapPropsToValues() {
    return {
      email: '',
      password: ''
    };
  },
  validationSchema: yup.object().shape({
    email: yup.string().required('Email required!').email('Email not valid!'),
    password: yup.string().required('Password is required!')
  }),
  validateOnBlur: true
});

export default compose(withTranslation(), withMap, formikForm)(Login);
