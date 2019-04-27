import React, { Component } from "react";
import { Route } from 'react-router-dom';
import { Nav, NavItem } from "./components/Navbar/Navbar";
import { PostView } from "./components/PostView/PostView"
import { HomePage } from "./pages/HomePage";
import { AboutPage} from "./pages/AboutPage";

class App extends Component {
  render() {
    return (
      <div>
        <Nav>
          <NavItem to="/">Home</NavItem>
          <NavItem to="/about">About</NavItem>
        </Nav>
        <Route exact path="/" component={HomePage}/>
        <Route path="/about" component={AboutPage}/>
        <Route path="/post" component={PostView}/>
      </div>
    );
  }
}

export default App;
