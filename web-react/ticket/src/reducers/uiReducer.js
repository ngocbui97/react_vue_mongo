import * as types from '../type';

const initState = {
  showLoading: false
};
const ui = (state = initState, action) => {
  switch (action.type) {
    case types.SHOW_LOADING:
      return { ...state, showLoading: true };
    case types.HIDE_LOADING:
      return { ...state, showLoading: false };
    default:
      return state;
  }
};

export default ui;
