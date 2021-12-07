import React from "react";
import { withRouter } from "react-router-dom";
import Header from "../components/Header";
import Answer from "../components/Answer";
import BASEAVATAR from "../assets/baseAvatar2wCircle.svg";
import { baseUsers } from "../datas/baseData";

class QuestionDetails extends React.PureComponent {
  constructor(props) {
    super(props);
    this.question = props.questions[props.match.params.id];
    this.answers = props.questions[props.match.params.id].posts.filter(
      (x) => x !== this.question.posts[props.match.params.id]
    );
  }

  componentDidMount() {
    // console.log('QuestionDetails Component : this.currentQuestion')
    // console.log(this.question)
    // console.log('QuestionDetails Component : this.answers')
    // console.log(this.answers)
  }

  getAvatar(writer) {
    if (baseUsers.find((x) => x.name === writer).avatar)
      return (
        <img
          src={baseUsers.find((x) => x.name === writer).avatar}
          alt="writer avatar"
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
      );
  }

  render() {
    return (
      <>
        <Header />
        <div className="question">
          <div className="question-header">
            <h1>{this.question.posts[0].title}</h1>
            <div className="question-details">
              {this.getAvatar(this.question.posts[0].writer)}
              <span>{this.question.creator}</span>
              <span>Asked on: {this.question.date}</span>
              <span>Viewed {this.question.views} times</span>
            </div>
            <hr />
          </div>

          <div className="question-body">
            <div className="question-content">
              {this.question.posts[0].content}
              <div className="question-tags">
              {this.question.tags.map((tag, index) => (
                <button key={index}>{tag}</button>
              ))}
            </div>
            </div>


            <div className="answers">
              <span className="answers-nb">
                {this.answers.length} Answers
              </span>
              {this.answers.map((answer, index) => (<>
                <Answer
                  key={index}
                  answer={answer}
                  getAvatar={this.getAvatar}
                  avatar={this.getAvatar(answer.writer)}
                />
                {index < this.answers.length - 1 ? <hr /> : null}
              </>))}
            </div>
          </div>

 

          <aside className="question-side">
            <h2>Linked</h2>
            <h2>Related</h2>
          </aside>
        </div>
      </>
    );
  }
}

export default withRouter(QuestionDetails);
