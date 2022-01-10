import React from 'react'
import {Link} from 'react-router-dom'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'
import '../styles/components/Question.css';

class Question extends React.PureComponent {
    constructor(props) {
        super(props)
    }

    getAvatar(user) {
        // if (baseUsers.find(x => x.username === user).avatar) return baseUsers.find(x => x.username === user).avatar
         return BASEAVATAR
    }

    formatDate(dateString) {
        return `${dateString.substr(8,2)}/${dateString.substr(5,2)}/${dateString.substr(0,4)}`
    }

    formatContentLength(string) {
        return string.length > 100 ? string.substr(0,100) + "..." : string;
    }

    render() {
        return (<>
            <article className="forum-question">
            <aside className="forum-counters">
                <div>{this.props.post.answers.length} answers</div>
                {/* <div>{this.props.post.score} score</div> */}
            </aside>
            <section className="forum-question__content">
                <Link to={`/question/${this.props.post.id}`}><h2>{this.props.post.title}</h2></Link>
                <p>{this.formatContentLength(this.props.post.content)}</p>
            </section>
            <aside className="forum-poster">
                <p className="forum-poster__asked">Asked : {this.formatDate(this.props.post.createdAt)}</p>
                <div className="forum-posterinfo">
                <img src={this.getAvatar(this.props.post.user)} alt="writer avatar" className="forum-poster__avatar"/>
                    <div className="forum-poster__name">{this.props.post.user?.username}</div>
                </div>
            </aside>
        </article>
        </>)
    }
}

export default Question;