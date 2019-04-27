import React, { Component } from 'react';
import { PostViewHeading } from "./PostViewHeading";
import './PostView.css'
import { fetchPost } from "../../callouts";

export class PostView extends Component {
    constructor() {
        super();
        this.state = {};
    }

    async componentDidMount() {
        const pathName = this.props.location.pathname;
        const postTitle = pathName.split("/")[2];
        const post = await fetchPost(postTitle);
        this.setState({
            title: post.title,
            date: post.createdDate,
            content: post.content
        });
    }
    
    render() {
        return (
            <div className="post-view">
                <PostViewHeading title={this.state.title} date={this.state.date}/>
                <div className="post-view__content">{this.state.content}</div>
            </div>
        );
    }
}