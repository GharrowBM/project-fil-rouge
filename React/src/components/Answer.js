import React from 'react'
import Comment from './Comment'
import {fetchPostWithId, submitNewComment, updateAnswerAction, updatePostAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import {withRouter} from "react-router-dom";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";
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

    postComment(e) {
        e.preventDefault()

        if (this.state.answerText.length > 0) {

        const newComment = {
            content: this.state.commentText,
            userId: this.props.currentUser.id,
            answerId: this.props.answer.id
        }

        this.props.submitNewComment(newComment)

        console.log(newComment);

        }
    }

    editAnswer(e) {
        e.preventDefault()

        const newAnswer = {
            content: this.state.answerText
        }

        this.props.updateAnswerAction(this.props.answer.id, newAnswer)
    }


    getAvatar() {
        /*if (baseUsers.find((x) => x.name === writer).avatar)
          return (
            <img
              src={baseUsers.find((x) => x.name === writer).avatar}
              alt="writer avatar"
              className="post-poster__avatar"
            />
          );
        else*/
        return (
            <img
                src={BASEAVATAR}
                alt="writer avatar"
                className="post-poster__avatar"
            />
        )
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
            {/* <div className="answer-score">
                Score: {this.props.answer.score}
            </div> */}
            <div className="answer-content">
                {this.state.isEditingAnswer ?
                    <div className="answer-content__toEdit">
                        <textarea value={this.state.answerText} onChange={(e) => this.setState({answerText: e.currentTarget.value})}></textarea>
                        <button onClick={(e) =>this.editAnswer(e)}>Submit Edited Answer</button>
                    </div>
                    : this.props.currentUser?.id == this.props.answer.user?.id ?
                        <div className="answer-content__toDisplay">
                            {this.props.answer.content}
                            <button onClick={() => this.setState({isEditingAnswer: !this.state.isEditingAnswer})}>Edit Answer</button>
                        </div>
                        : <div className="answer-content__toDisplay"> {this.props.answer.content} </div>}
    {           <div className="answer-comments">
                    {this.props.answer.comments?.map((comment,index) => <Comment key={comment.id}
                                                                                 avatar={this.getAvatar()}
                                                                                 comment={comment}/>)}
                    {this.props.currentUser ?                     <div>
                        <textarea type="text" placeholder="Your comment here..."
                               name={`new-comment-answer-${this.props.answer.id}`}
                               id={`new-comment-answer-${this.props.answer.id}`} value={this.state.commentText}
                               onChange={(e) => this.setState({commentText: e.currentTarget.value})}></textarea>
                        <button onClick={(e) => this.postComment(e)}>Send Comment</button>
                    </div> : null}
                </div>}
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
        submitNewComment: (comment) => dispatch(submitNewComment(comment)),
        updateAnswerAction: (id, answer) => dispatch(updateAnswerAction(id, answer))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(Answer))