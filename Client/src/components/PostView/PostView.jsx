import React, { Component } from 'react';
import './PostView.css'
import { fetchPost } from "../../callouts";

export class PostView extends Component {
    constructor() {
        super();
        this.state = {};
    }

    async componentDidMount() {
        const pathName = this.props.location.pathname;
        const postTitle = pathName.split("/")[2]
        const post = await fetchPost(postTitle);
        this.setState({ title: post.title, content: post.content });
    }
    
    render() {
        return (
            <div className="post-preview-card">
                <h3 className="post-preview-card__heading">{this.state.title}</h3>
                <p>{this.state.content}</p>
            </div>
        );
    }
}