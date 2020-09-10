import PropTypes from 'prop-types';
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { compose } from 'redux';
// import LoadingIcon from './../../assets/images/loading.gif';
import { Dimmer, Loader, Segment } from 'semantic-ui-react';

class GlobalLoading extends Component {
  render() {
    const { showLoading } = this.props;
    console.log(this.props);
    let xhtml = null;
    if (showLoading) {
      xhtml = (
        <div>
          <Segment>
            <Dimmer active>
              <Loader />
            </Dimmer>
          </Segment>
        </div>
      );
    }
    return xhtml;
  }
}

GlobalLoading.propTypes = {
  classes: PropTypes.object,
  showLoading: PropTypes.bool
};

const mapStateToProps = (state) => {
  console.log(state);
  return {
    showLoading: state.ui.showLoading
  };
};

const withConnect = connect(mapStateToProps, null);

export default compose(withConnect)(GlobalLoading);
