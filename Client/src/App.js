import React, { Component } from "react";
import { PostList } from "./components/PostList/PostList";
import { Navbar } from "./components/Navbar/Navbar";
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
        <Navbar />
        <PostList posts={this.state.posts} />
      </div>
    );
  }
}

export default App;
