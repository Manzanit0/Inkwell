import React, { Component } from "react";
import { PostForm } from "../components/PostForm/PostForm";

export class AddPostPage extends Component {
  render() {
    return (
      <div style={{margin: "100px"}}>
        <PostForm/>
      </div>
    );
  }
}