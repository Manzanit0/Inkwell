import React, { Component } from "react";

export class PostForm extends Component {
  render() {
    return (
      <div>
        <form className="post-form">
          <TextArea label="Content"/>
          <SubmitButton label="Create" onSubmit={this.handleSubmit}/>
        </form>
      </div>
    );
  }
  
  handleSubmit = (event) => {
    alert('An essay was submitted: ' + this.state.value);
    event.preventDefault();
  }
}

class TextArea extends Component {
  constructor(props) {
    super(props);
    this.state = { value: '' };
  }
  
  render() {
    return (
      <div>
        <label>{this.props.label}</label>
        <textarea rows="5"
                  cols="33"
                  placeholder="Write here..."
                  value={this.state.value}
                  onChange={this.handleChange} />
      </div>
    );
  }
  
  handleChange = (event) =>
    this.setState({value: event.target.value});
}

class SubmitButton extends Component {
  render() {
    return (
      <div>
        <input type="submit" value={this.props.label} onSubmit={this.props.onSubmit} />
      </div>
    );
  } 
  
}