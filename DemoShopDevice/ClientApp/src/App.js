import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';
import  DevicePage from './pages/DevicePage';
import Shop from './pages/Shop';
import Auth from './pages/Auth';
import Admin from './pages/Admin';
import Basket from './pages/Basket';
import {
    BASKET_ROUTE,
    SHOP_ROUTE,
    REGISTRATION_ROUTE,
    LOGIN_ROUTE,
    ADMIN_ROUTE
} from "./utils/consts";

import './custom.css'

export default class App extends Component {
    static displayName = App.name;
   

    render() {
  
      return (
          <Layout>
              <Route path={SHOP_ROUTE} component={Shop} />
              <Route path={'/device/:id'} component={DevicePage} />
              <Route path={REGISTRATION_ROUTE} component={Auth} />
              <Route path={BASKET_ROUTE} component={Basket} />   
              <Route path={ADMIN_ROUTE} component={Admin} />
          </Layout>
    );
  }
}
