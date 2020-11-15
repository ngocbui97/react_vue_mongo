import React, { Component } from 'react';
import Header from '../../components/header';
import Body from '../../components/body';
import Footer from '../../components/footer';

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
        <div className="sixteen wide column content">
          <Body></Body>
        </div>
        <div className="sixteen wide column footer">
          <Footer></Footer>
        </div>
      </div>
    );
  }
}

export default Home;
