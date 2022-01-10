import React from "react";
import {withRouter} from "react-router-dom";
import Answer from "../components/Answer";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";
import {fetchPostWithId, submitNewAnswer, updatePostAction} from "../store/actions/postsActions";
import {connect} from "react-redux";
import '../styles/containers/QuestionDetails.css';
import answer from "../components/Answer";

class QuestionDetails extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            answerText: ""
        }
    }

    componentDidMount() {
        this.props.fetchPostWithId(this.props.match.params.id)
    }

    formatDate(dateString) {
        return `${dateString.substr(8, 2)}/${dateString.substr(5, 2)}/${dateString.substr(0, 4)} at ${dateString.substr(11, 8)}`
    }

    submitAnswer(e) {
        e.preventDefault()

        if (this.state.answerText.length > 0) {

            const newAnswer = {
                userId: this.props.currentUser.id,
                postId: this.props.currentPost.id,
                content: this.state.answerText
            }

            this.props.submitNewAnswer(newAnswer, this.props.currentPost.id)
            console.log(this.props.currentPost)
        }
    }

    getAvatar(writer) {
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
        if (this.props.currentPost !== undefined) {

            return (
                <>
                    <div className="question">
                        <div className="question-header">
                            <h1>{this.props.currentPost.title}</h1>
                            <div className="question-details">
                                <div className="question-poster">
                                    {this.getAvatar(this.props.currentPost.user.username)}
                                    <span className="question-poster__name">{this.props.currentPost.user.username}</span>
                                </div>
                                <div className="question-infos">
                                    <div className="question-date">Asked on: {this.formatDate(this.props.currentPost.createdAt)}</div>
                                    {/* <div className="question-views">Viewed {this.props.currentPost.score} times</div> */}
                                </div>
                            </div>
                            <hr/>
                        </div>

                        <div className="question-body">
                            <div className="question-content">
                                {this.props.currentPost.content}
                                <div className="question-tags">
                                    {this.props.currentPost.tags.map((tag, index) => (
                                        <button key={index}>{tag}</button>
                                    ))}
                                </div>
                            </div>


                            <div className="answers">
              <span className="answers-nb">
                {this.props.currentPost.answers.length} Answers
              </span>
                                {this.props.currentPost.answers?.map((answer,index) => (<>
                                    <Answer
                                        key={answer.id}
                                        answer={this.props.currentPost.answers[index]}
                                        getAvatar={this.getAvatar}
                                        avatar={this.getAvatar(answer.writer)}
                                    />
                                    {index < this.props.currentPost.answers.length - 1 ? <hr/> : null}
                                </>))}
                                {this.props.currentUser ? <div className="new-answer-zone">
                                    <textarea placeholder="Write a new answer here..." value={this.state.answerText}
                                           onChange={(e) => this.setState({answerText: e.currentTarget.value})}></textarea>
                                    <button onClick={(e) => this.submitAnswer(e)}>New answer</button>
                                </div> : null}
                            </div>
                        </div>
                    </div>
                </>
            )
        } else {
            return (<><p>Loading post...</p></>)
        }
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
        fetchPostWithId: (id) => dispatch(fetchPostWithId(id)),
        updatePostAction: (id, post) => dispatch(updatePostAction(id, post)),
        submitNewAnswer: (answer, postId) => dispatch(submitNewAnswer(answer, postId))
    }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(QuestionDetails))
