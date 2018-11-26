import React, { Component } from 'react';
import { PostList } from './components/PostList/PostList';
import { Navbar } from './components/Navbar/Navbar';

class App extends Component {
  constructor() {
    super();

    this.state = { posts: [] };

    fetch('https://localhost:5001/api/posts') // C# API.
      .then(response => {
        return response.json();
      })
      .then(myJson => {
        const posts = myJson.map(post => {
          post.blurb = post.content.substring(0, 120) + "...";
          return post;
        });

        this.setState({posts: posts});
      });
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
