import React from 'react'
import Comment from './Comment'

class Answer extends React.PureComponent {

    componentDidMount() {
        // console.log('Post Component : this.post')
        // console.log(this.post)
    }

    render() {
        return(<article className="answer">
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
                {this.props.answer.comments.map((comment, index) => <Comment key={index} avatar={this.props.getAvatar(comment.writer)} comment={comment}/>)}
                <input type="text" name={`new-comment-answer-${this.props.answer.id}`} id={`new-comment-answer-${this.props.answer.id}`} />
                </div>                
            </div>
        </article>)
    }
}

export default Answer