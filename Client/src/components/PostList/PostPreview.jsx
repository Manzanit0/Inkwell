import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './PostPreview.css'

export class PostPreview extends Component {
    render() {
        return (
            <Link to={{pathname: `/post/${this.props.title}`}} style={{ textDecoration: 'none', color: 'black'}}>
                <div className="post-preview-card">
                    <h3 className="post-preview-card__heading">{this.props.title}</h3>
                    <p>{this.props.blurb}</p>
                </div>
            </Link>
        );
    }
}