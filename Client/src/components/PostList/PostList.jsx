import React, { Component } from 'react';
import { PostPreview } from './PostPreview';
import './PostList.css'

export class PostList extends Component {
  render() {
    return (
      <div className="post-list">
        {this.props.posts.map(post => {
          return <PostPreview {...post} />
        })}
      </div>
    );
  }
}