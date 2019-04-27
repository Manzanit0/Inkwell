import React, { Component } from 'react';
import { NavLink } from "react-router-dom";
import './Navbar.css'

class Nav extends Component {
  render() {
    return (
      <div>
          <ul className="nav">
            {this.props.children.map(child =>
              <li className="nav__element">{child}</li>)}
          </ul>
      </div>
    );
  }
}

const NavItem =
  (props) => <NavLink {...props} exact="/" activeClassName="nav__element--active" />

export { Nav, NavItem }
