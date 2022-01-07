import React from "react";
import { withRouter } from "react-router-dom";
import Header from "../components/Header";
import Answer from "../components/Answer";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";
import { getPost } from "../services/dataService";

class QuestionDetails extends React.PureComponent {
  constructor(props) {
    super(props);
    this.state = {
      post: undefined,
  }
    // this.question = props.questions[props.match.params.id];
    // this.answers = props.questions[props.match.params.id].posts.filter(
    //   (x) => x !== this.question.posts[props.match.params.id]
    // );
  }

  componentDidMount() {
    // console.log('QuestionDetails Component : this.currentQuestion')
    // console.log(this.question)
    // console.log('QuestionDetails Component : this.answers')
    // console.log(this.answers)
    getPost(this.props.match.params.id).then(res => {
        this.setState({post: [...res.data] })
    })
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
    if (this.state.post) {
      return (
          <>
            <Header />
            <div className="question">
              <div className="question-header">
                <h1>{this.state.post.title}</h1>
                <div className="question-details">
                  {/* {this.getAvatar(this.state.post.user)} */}
                  <span>{this.state.post.user.username}</span>
                  <span>Asked on: {this.state.post.createdAt}</span>
                  <span>Viewed {this.state.post.score} times</span>
                </div>
                <hr />
              </div>

              <div className="question-body">
                <div className="question-content">
                  {this.state.post.content}
                  <div className="question-tags">
                    {this.state.post.tags.map((tag, index) => (
                        <button key={index}>{tag}</button>
                    ))}
                  </div>
                </div>


                <div className="answers">
              <span className="answers-nb">
                {this.state.post.answers.length} Answers
              </span>
                  {this.state.post.answers.map((answer, index) => (<>
                    <Answer
                        key={index}
                        answer={answer}
                        getAvatar={this.getAvatar}
                        avatar={this.getAvatar(answer.writer)}
                    />
                    {index < this.state.post.answers.length - 1 ? <hr /> : null}
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

export default withRouter(QuestionDetails);
