import React, { Component } from 'react';
import { Grid, List, Header, Icon } from 'semantic-ui-react';
import history from '../../common/history';
import './index.scss';

class Footer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      signIn: false
    };
  }

  render() {
    return (
      <div className="footer">
        <Grid divided inverted stackable>
          <Grid.Row>
            <Grid.Column width={4}>
              <Header inverted as="h4" content="About" />
              <List link inverted>
                <List.Item as="a">Sitemap</List.Item>
                <List.Item as="a">Contact Us</List.Item>
                <List.Item as="a">Religious Ceremonies</List.Item>
                <List.Item as="a">Gazebo Plans</List.Item>
              </List>
            </Grid.Column>
            <Grid.Column width={4}>
              <Header inverted as="h4" content="Services" />
              <List link inverted>
                <List.Item as="a">Banana Pre-Order</List.Item>
                <List.Item as="a">DNA FAQ</List.Item>
                <List.Item as="a">How To Access</List.Item>
                <List.Item as="a">Favorite X-Men</List.Item>
              </List>
            </Grid.Column>
            <Grid.Column width={4}>
              <Header inverted as="h4" content="Addmin" />
              <List link inverted>
                <List.Item as="a">Banana Pre-Order</List.Item>
                <List.Item as="a">DNA FAQ</List.Item>
                <List.Item as="a">How To Access</List.Item>
                <List.Item as="a">Favorite X-Men</List.Item>
              </List>
            </Grid.Column>
            <Grid.Column width={4}>
              <Header inverted as="h4" content="Contact" />
              <List link inverted>
                <List.Item as="text">
                  <Icon name="mail" className="icon-footer"></Icon>
                  buinhungoc97@gmail.com
                </List.Item>
                <List.Item as="text">
                  <Icon name="phone" className="icon-footer"></Icon>0364285021
                </List.Item>
                <List.Item as="text">Copyright © 2020 · jobviet</List.Item>
              </List>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </div>
    );
  }
}
export default Footer;
