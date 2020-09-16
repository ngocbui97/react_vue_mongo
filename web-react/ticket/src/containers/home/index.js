import React, { Component } from 'react';
import Header from '../../components/header';

class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }
  render() {
    return (
      <div className="home row">
        <div className="header sixteen wide column">
          <Header></Header>
        </div>
        <div className="sixteen wide column content"></div>
        <div className="sixteen wide column footer"></div>
      </div>
    );
  }
}

export default Home;
