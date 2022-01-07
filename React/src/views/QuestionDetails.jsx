import React from "react";
import { withRouter } from "react-router-dom";
import Header from "../components/Header";
import Answer from "../components/Answer";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";
import { getPost } from "../services/dataService";
import {fetchPost, fetchPosts} from "../store/actions/postsActions";
import {connect} from "react-redux";

class QuestionDetails extends React.PureComponent {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.fetchPost(this.props.match.params.id)
    console.log(this.props.post)
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
    if (this.props.post !== undefined) {

      return (
          <>
            <Header />
            <div className="question">
              <div className="question-header">
                <h1>{this.props.post.title}</h1>
                <div className="question-details">
                  {/* {this.getAvatar(this.state.post.user)} */}
                  <span>{this.props.post.user.username}</span>
                  <span>Asked on: {this.props.post.createdAt}</span>
                  <span>Viewed {this.props.post.score} times</span>
                </div>
                <hr />
              </div>

              <div className="question-body">
                <div className="question-content">
                  {this.props.post.content}
                  <div className="question-tags">
                    {this.props.post.tags.map((tag, index) => (
                        <button key={index}>{tag}</button>
                    ))}
                  </div>
                </div>


                <div className="answers">
              <span className="answers-nb">
                {this.props.post.answers.length} Answers
              </span>
                  {this.props.post.answers.map((answer, index) => (<>
                    <Answer
                        key={index}
                        answer={answer}
                        getAvatar={this.getAvatar}
                        avatar={this.getAvatar(answer.writer)}
                    />
                    {index < this.props.post.answers.length - 1 ? <hr /> : null}
                  </>))}
                </div>
              </div>



              <aside className="question-side">
                <h2>Linked</h2>
                <h2>Related</h2>
              </aside>
            </div>
          </>
      )
    }
    else {
      return (<><p>Loading post...</p></>)
    }
  }
}

const mapStateToProps = (state) => {
  return {
    loading: state.postsStore.isLoading,
    post: state.postsStore.post
  }
}

const mapActionToProps = (dispatch) => {
  return {
    fetchPost: (id) => dispatch(fetchPost(id))
  }
}

export default connect(mapStateToProps, mapActionToProps)(withRouter(QuestionDetails))
