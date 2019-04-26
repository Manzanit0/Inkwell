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
            <div className="post-view">
                <h3 className="post-view__title">{this.state.title}</h3>
                <div className="post-view__content">{this.state.content}</div>
            </div>
        );
    }
}