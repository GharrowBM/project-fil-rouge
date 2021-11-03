import React from 'react'
import {withRouter} from 'react-router-dom'
import Header from '../components/Header'
import Post from '../components/Post'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'
import {baseUsers} from '../datas/baseData'

class QuestionDetails extends React.PureComponent {

    constructor(props) {
        super(props)
        this.question = props.questions[props.match.params.id]
        this.answers = props.questions[props.match.params.id].posts.filter(x => x !== this.question.posts[props.match.params.id])
    }

    componentDidMount() {
        // console.log('QuestionDetails Component : this.currentQuestion')
        // console.log(this.question)
        // console.log('QuestionDetails Component : this.answers')
        // console.log(this.answers)
    }

    getAvatar(writer) {
        if (baseUsers.find(x => x.name === writer).avatar) return <img src={baseUsers.find(x => x.name === writer).avatar} alt="writer avatar" className="post-poster__avatar"/>
        else return <img src={BASEAVATAR} alt="writer avatar" className="post-poster__avatar"/>
    }

    render() {

        return (<>
        <Header />
        <div className="question-header">
            <h1>{this.question.posts[0].title}</h1>
            <div className="question-details">
            {this.getAvatar(this.question.posts[0].writer)}
            <span>{this.question.creator}</span>
            <span>Asked on: {this.question.date}</span>
            <span>Viewed {this.question.views} times</span>
            </div>
        </div>

        <div className="question-body">
        <div className="question-content">
                {this.question.posts[0].content}
            </div>
            <div className="question-tags">
                {this.question.tags.map((tag, index) => <button key={index}>{tag}</button>)}
            </div>
            <div className="answers">
            {this.answers.map((post, index) => <Post key={index} post={post} avatar={this.getAvatar(post.writer)}/>)}
        </div>
        <aside>
            <h2>Linked</h2>
            <h2>Related</h2>
        </aside>
        </div>

        

        </>)
    }
}

export default withRouter(QuestionDetails)