import React, { Component } from "react";
import { Route } from 'react-router-dom';
import { PostList } from "./components/PostList/PostList";
import { Nav, NavItem } from "./components/Navbar/Navbar";
import { PostView } from "./components/PostView/PostView"
import { AboutPage} from "./pages/AboutPage";
import { fetchPostsWithBlurb } from "./callouts";

class App extends Component {
    constructor() {
        super();
        this.state = { posts: [] };
    }

    async componentDidMount() {
        const posts = await fetchPostsWithBlurb();
        this.setState({ posts: posts });
    }

    render() {
        return (
            <div>
                <Nav>
                  <NavItem to="/">Home</NavItem>
                  <NavItem to="/about">About</NavItem>
                </Nav>
                <Route exact path="/" render={props => <PostList posts={this.state.posts} />}/>
                <Route path="/post" component={PostView}/>
                <Route path="/about" component={AboutPage}/>
            </div>
        );
    }
}

export default App;
