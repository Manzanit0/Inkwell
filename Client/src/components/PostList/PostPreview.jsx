import React, { Component } from 'react';
import './PostPreview.css'

export class PostPreview extends Component {
  render() {
    return (
      <div className="post-preview-card">
        <h3 className="post-preview-card__heading">{this.props.title}</h3>
        <p>{this.props.blurb}</p>
      </div>
    );
  }
}