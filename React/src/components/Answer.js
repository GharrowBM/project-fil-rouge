import React from 'react'
import Comment from './Comment'
import {fetchPostWithId, updatePostAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import {withRouter} from "react-router-dom";
import '../styles/components/Answer.css';
import answer from "./Answer";

class Answer extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            commentText: "",
            answerText: this.props.answer.content,
            isEditingAnswer: false
        }
    }

    formatDate(dateString) {
        return `${dateString.substr(8, 2)}/${dateString.substr(5, 2)}/${dateString.substr(0, 4)} at ${dateString.substr(11, 8)}`
    }

    postComment(e, answerId) {
        e.preventDefault()

        const newComment = {
            content: this.state.commentText,
            userId: this.props.currentUser.id,
            answerId: answerId
        }

        const postToEdit = this.props.currentPost
        postToEdit.answers.find(a => a.id == answerId).comments?.push(newComment)

        this.props.updatePostAction(this.props.currentPost.id, postToEdit)
    }

    editAnswer(e) {
        e.preventDefault()

        const postToEdit = this.props.currentPost
        postToEdit.answers.find(a => a.id == this.props.answer.id).content = this.state.answerText

        this.props.updatePostAction(this.props.currentPost.id, postToEdit)
    }

    render() {
        return (<article className="answer">
            <div className="answer-writer">
                {this.props.avatar}
                <span>{this.props.answer.user?.username}</span>
            </div>
            <div className="answer-date">
                <span>Answered {this.formatDate(this.props.answer.createdAt)}</span>
            </div>
            <div className="answer-score">
                Score: {this.props.answer.score}
            </div>
            <div className="answer-content">
                {this.state.isEditingAnswer ?
                    <div>
                        <input type="text" value={this.state.answerText} onChange={(e) => this.setState({answerText: e.currentTarget.value})}/>
                        <button onClick={(e) =>this.editAnswer(e)}>Submit</button>
                    </div>
                    : this.props.currentUser?.id == this.props.answer.user.id ?
                        <div>
                            {this.props.answer.content}
                            <button onClick={() => this.setState({isEditingAnswer: !this.state.isEditingAnswer})}>Edit</button>
                        </div>
                        :  this.props.answer.content}
                <div className="answer-comments">
                    {this.props.answer.comments?.map((comment,index) => <Comment key={comment.id}
                                                                                 avatar={this.props.getAvatar(comment.writer)}
                                                                                 comment={comment}/>)}
                    {this.props.currentUser ?                     <div>
                        <textarea type="text" placeholder="Your comment here..."
                               name={`new-comment-answer-${this.props.answer.id}`}
                               id={`new-comment-answer-${this.props.answer.id}`} value={this.state.commentText}
                               onChange={(e) => this.setState({commentText: e.currentTarget.value})}></textarea>
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
        currentUser: state.users.currentUser,
        allPosts: state.posts.allPosts
    }
}

const mapActionToProps = (dispatch) => {
    return {
        updatePostAction: (id, post) => dispatch(updatePostAction(id, post))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Answer))