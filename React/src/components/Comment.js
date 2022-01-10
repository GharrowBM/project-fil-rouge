import React from "react";
import '../styles/components/Comment.css';
import {updateCommentAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import {withRouter} from "react-router-dom";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";


class Comment extends React.PureComponent {
constructor(props) {
    super(props)
    this.state = {
        commentText: this.props.comment.content,
        isEditingComment: false
    }
}

    formatDate(dateString) {
        return `${dateString.substr(8, 2)}/${dateString.substr(5, 2)}/${dateString.substr(0, 4)} at ${dateString.substr(11, 8)}`
    }

    getAvatar(writerId) {
        if (this.props.allAvatarPath.find(x => x.userId === this.props.currentPost.id))
            return (
                <img
                    src={this.props.allAvatarPath.find(x => x.userId === this.props.currentPost.id).avatarPath}
                    alt={this.props.currentPost.user.username}
                    className="post-poster__avatar"
                />
            );
        else
            return (
                <img
                    src={BASEAVATAR}
                    alt="writer avatar"
                    className="post-poster__avatar"
                />
            )
    }

    editComment(e) {
        e.preventDefault()

        const newComment = {
            content: this.state.commentText
        }

        this.props.updateCommentAction(this.props.comment.id, newComment, this.props.currentPost.id)

        this.state.isEditingComment = false
    }

  render() {
    return (
      <div className="comment">
        <div className="comment-writer">
          {this.getAvatar(this.props.comment.user.id)}
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
                  :<div className="comment-content__toDisplay">  {this.props.comment.content}</div>}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        currentPost: state.posts.currentPost,
        currentUser: state.users.currentUser,
        allPosts: state.posts.allPosts,
        allAvatarPath: state.posts.allAvatarPath
    }
}

const mapActionToProps = (dispatch) => {
    return {
        updateCommentAction: (id, comment, postId) => dispatch(updateCommentAction(id, comment, postId))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Comment))
