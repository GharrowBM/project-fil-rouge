import React from 'react'
import {Link} from 'react-router-dom'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'
import '../styles/components/Question.css';

class Question extends React.PureComponent {
    constructor(props) {
        super(props)
        this.index = props.index
        this.post = props.post
    }

    getAvatar(user) {
        // if (baseUsers.find(x => x.username === user).avatar) return baseUsers.find(x => x.username === user).avatar
         return BASEAVATAR
    }

    formatDate(dateString) {
        return `${dateString.substr(8,2)}/${dateString.substr(5,2)}/${dateString.substr(0,4)}`
    }

    render() {
        return (<>
            <article className="forum-question">
            <aside className="forum-counters">
                <div>{this.post.answers.length} answers</div>
                {/* <div>{this.post.score} score</div> */}
            </aside>
            <section className="forum-question__content">
                <Link to={`/question/${this.post.id}`}><h2>{this.post.title}</h2></Link>
                <p>{this.post.content}</p>
            </section>
            <aside className="forum-poster">
                <p className="forum-poster__asked">Asked : {this.formatDate(this.post.createdAt)}</p>
                <div className="forum-posterinfo">
                <img src={this.getAvatar(this.post.user)} alt="writer avatar" className="forum-poster__avatar"/>
                    <div className="forum-poster__name">{this.post.user?.username}</div>
                </div>
            </aside>
        </article>
        </>)
    }
}

export default Question;