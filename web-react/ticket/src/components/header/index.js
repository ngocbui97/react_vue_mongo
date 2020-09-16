import React, { Component } from 'react';
import { Button, Dropdown, Menu } from 'semantic-ui-react';
import history from '../../common/history';
import { Redirect, withRouter } from 'react-router-dom';

class Header extends Component {
  constructor(props) {
    super(props);
    this.state = {
      signIn: false
    };
  }

  state = { activeItem: 'home' };
  handleItemClick = (e, { name }) => this.setState({ activeItem: name });
  handleSignIn = () => {
    history.push('/login');
  };

  render() {
    const { activeItem } = this.state;

    return (
      <Menu size="tiny">
        <Menu.Item
          name="home"
          active={activeItem === 'home'}
          onClick={this.handleItemClick}
        />
        <Menu.Item
          name="messages"
          active={activeItem === 'messages'}
          onClick={this.handleItemClick}
        />

        <Menu.Menu position="right">
          <Dropdown item text="Language">
            <Dropdown.Menu>
              <Dropdown.Item>English</Dropdown.Item>
              <Dropdown.Item>Russian</Dropdown.Item>
              <Dropdown.Item>Spanish</Dropdown.Item>
            </Dropdown.Menu>
          </Dropdown>

          <Menu.Item>
            <Button primary onClick={this.handleSignIn}>
              Sign Up
            </Button>
          </Menu.Item>
        </Menu.Menu>
      </Menu>
    );
  }
}
export default withRouter(Header);
