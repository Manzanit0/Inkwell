import React, { Component } from 'react';
import { PostList } from './components/PostList/PostList';
import { Navbar } from './components/Navbar/Navbar';

class App extends Component {
  render() {
    const posts = [
      { title: "First post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "Another post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "First post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "Another post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "First post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "Another post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "First post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "Another post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." },
      { title: "Yet another post", blurb: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque non nunc ac nibh dictum mattis nec ut mauris..." }
    ]

    return (
      <div>
        <Navbar />
        <PostList posts={posts} />
      </div>
    );
  }
}

export default App;
