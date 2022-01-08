import React from 'react'
import Comment from './Comment'
import {fetchPostWithId, updatePostAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import {withRouter} from "react-router-dom";

class Answer extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            commentText: ""
        }
    }

    postComment(e, answerId) {
        e.preventDefault()

        const newComment = {
            content: this.state.commentText,
            userId: this.props.currentUser.id,
            answerId: answerId
        }

        const postToEdit = this.props.currentPost
        postToEdit.answers.find(a => a.id == answerId).comments.push(newComment)

        this.props.updatePostAction(this.props.currentPost.id, postToEdit)
    }

    render() {
        return (<article className="answer">
            <div className="answer-writer">
                {this.props.avatar}
                <span>{this.props.answer.writer}</span>
            </div>
            <div className="answer-date">
                <span>Answered {this.props.answer.date}</span>
            </div>
            <div className="answer-score">
                {this.props.answer.score}
            </div>
            <div className="answer-content">
                {this.props.answer.content}
                <div className="answer-comments">
                    {this.props.answer.comments.map((comment, index) => <Comment key={index}
                                                                                 avatar={this.props.getAvatar(comment.writer)}
                                                                                 comment={comment}/>)}
                    {this.props.currentUser ?                     <div>
                        <input type="text" placeholder="Your comment here..."
                               name={`new-comment-answer-${this.props.answer.id}`}
                               id={`new-comment-answer-${this.props.answer.id}`} value={this.state.commentText}
                               onChange={(e) => this.setState({commentText: e.currentTarget.value})}/>
                        <button onClick={(e) => this.postComment(e, this.props.answer.id)}>Envoyer le commentaire</button>
                    </div> : null}
                </div>
            </div>
        </article>)
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        currentPost: state.posts.currentPost,
        currentUser: state.users.currentUser
    }
}

const mapActionToProps = (dispatch) => {
    return {
        updatePostAction: (id, post) => dispatch(updatePostAction(id, post))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Answer))