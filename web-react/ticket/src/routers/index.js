import Login from '../components/login';
import Home from '../containers/home';

const routes = [
  {
    name: 'Page login',
    path: '/login',
    exact: true,
    component: Login
  },
  {
    name: 'Page home',
    path: '',
    exact: true,
    component: Home
  }
  //   {
  //     path: '/tacos',
  //     component: Tacos,
  //     routes: [
  //       {
  //         path: '/tacos/bus',
  //         component: Bus
  //       },
  //       {
  //         path: '/tacos/cart',
  //         component: Cart
  //       }
  //     ]
  //   }
];
export default routes;
