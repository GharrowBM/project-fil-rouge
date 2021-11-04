import React from "react";

class Comment extends React.PureComponent {
  render() {
    return (
      <div className="comment">
        <div className="comment-writer">
          {this.props.avatar}
          <span>{this.props.comment.writer}</span>
        </div>
        <div className="comment-date">
          <span>{this.props.comment.date} </span>
        </div>
        <div className="comment-score">
          <span>{this.props.comment.score}</span>
        </div>
        <div className="comment-content">{this.props.comment.content}</div>
      </div>
    );
  }
}

export default Comment;
