import React, { Component } from 'react';
import { PostList } from "../components/PostList/PostList";
import { fetchPostsWithBlurb } from "../callouts";

export class HomePage extends Component {
  constructor(props) {
    super(props);
    this.state = { posts: [] };
  }
  
  async componentDidMount() {
    const posts = await fetchPostsWithBlurb();
    this.setState({ posts: posts });
  }
  
  render() {
    return (
      <div>
        <PostList posts={this.state.posts} />
      </div>
    );
  }
}