import React from 'react'
import {Link} from 'react-router-dom'
import {baseUsers} from '../datas/baseData'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'

class Question extends React.PureComponent {
    constructor(props) {
        super(props)
        this.index = props.index
        this.forum = props.forum
    }

    getAvatar(writer) {
        if (baseUsers.find(x => x.name === writer).avatar) return baseUsers.find(x => x.name === writer).avatar
        else return BASEAVATAR
    }

    render() {
        return (<>
            <article className="forum-question">
            <aside className="forum-counters">
                <div>{this.forum.answers} answers</div>
                <div>{this.forum.views} views</div>
            </aside>
            <section className="forum-question__content">
                <Link to={`/question/${this.forum.id}`}><h2>{this.forum.posts[0].title}</h2></Link>
                <p>{this.forum.posts[0].content}</p>
            </section>
            <aside className="forum-poster">
                <p className="forum-poster__asked">Asked : {this.forum.posts[0].date}</p>
                <div className="forum-posterinfo">
                <img src={this.getAvatar(this.forum.posts[0].writer)} alt="writer avatar" className="forum-poster__avatar"/>
                    <div className="forum-poster__name">{this.forum.creator}</div>
                </div>
            </aside>
        </article>
        </>)
    }
}

export default Question;