import React, { Component } from 'react';
import './Navbar.css'

export class Navbar extends Component {
  render() {
    return (
      <div>
        <ul className="nav">
          <li className="nav__element nav__element--active"><a href="/">Home</a></li>
          <li className="nav__element"><a href="###">Content</a></li>
          <li className="nav__element"><a href="/about">About</a></li>
        </ul>
      </div>
    );
  }
}