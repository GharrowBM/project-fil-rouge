import React from "react";
import '../styles/components/Comment.css';
import {updateCommentAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import {withRouter} from "react-router-dom";


class Comment extends React.PureComponent {
constructor(props) {
    super(props)
    this.state = {
        commentText: "",
        isEditingComment: false
    }
}

    formatDate(dateString) {
        return `${dateString.substr(8, 2)}/${dateString.substr(5, 2)}/${dateString.substr(0, 4)} at ${dateString.substr(11, 8)}`
    }

    editComment(e) {
        e.preventDefault()

        const commentToEdit = this.props.comment
        commentToEdit.content = this.state.commentText

        this.props.updateCommentAction(this.props.comment.id, commentToEdit)
    }

  render() {
    return (
      <div className="comment">
        <div className="comment-writer">
          {this.props.avatar}
          <span>{this.props.comment.user.username}</span>
        </div>
        <div className="comment-date">
          <span>Commented {this.formatDate(this.props.comment.createdAt)} </span>
        </div>
        <div className="comment-score">
          <span></span>
        </div>
          {this.state.isEditingComment ?
              <div className="comment-content__toEdit">
                  <textarea placeholder="Your comment to edit here..." value={this.state.commentText} onChange={(e) => this.setState({commentText: e.currentTarget.value})}></textarea>
                  <button onClick={(e) =>this.editComment(e)}>Submit Edited Comment</button>
              </div>
              : this.props.currentUser?.id == this.props.comment.user.id ?
                  <div className="comment-content__toDisplay">
                      {this.props.comment.content}
                      <button onClick={() => this.setState({isEditingComment: !this.state.isEditingComment})}>Edit Comment</button>
                  </div>
                  :  this.props.comment.content}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        currentPost: state.posts.currentPost,
        currentUser: state.users.currentUser,
        allPosts: state.posts.allPosts
    }
}

const mapActionToProps = (dispatch) => {
    return {
        updateCommentAction: (id, comment) => dispatch(updateCommentAction(id, comment))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Comment))
