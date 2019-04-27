import React, { Component } from 'react';
import './PostViewHeading.css'

export class PostViewHeading extends Component {
    render() {
        return (
            <div className="post-view-heading">
                <h2 className="post-view-heading__title">{this.props.title}</h2>
                <h4 className="post-view-heading__subtitle">{this.props.date}</h4>
                <hr/>
            </div>
        );
    }
}