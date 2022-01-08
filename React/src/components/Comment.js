import React from "react";
import '../styles/components/Comment.css';
import {updatePostAction} from "../store/actions/postsActions";
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

        const postToEdit = this.props.currentPost
        postToEdit.answers[this.props.comment.answerId].content = this.state.commentText

        this.props.updatePostAction(this.props.currentPost.id, postToEdit)
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
          <span>{this.props.comment.score}</span>
        </div>
          {this.state.isEditingComment ?
              <div>
                  <input type="text" value={this.state.commentText} onChange={(e) => this.setState({commentText: e.currentTarget.value})}/>
                  <button onClick={(e) =>this.editComment(e)}>Submit</button>
              </div>
              : this.props.currentUser?.id == this.props.comment.user.id ?
                  <div>
                      {this.props.comment.content}
                      <button onClick={() => this.setState({isEditingComment: !this.state.isEditingComment})}>Edit</button>
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
        updatePostAction: (id, post) => dispatch(updatePostAction(id, post))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Comment))
