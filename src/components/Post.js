import React from 'react'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'
import {baseUsers} from '../datas/baseData'

class Post extends React.PureComponent {
    constructor(props) {
        super(props)
        this.post = props.post
    }

    componentDidMount() {
        console.log('Post Component : this.post')
        console.log(this.post)
    }

    render() {
        return(<>
            <article className="post-question">
            <aside className="post-poster">
                <p className="post-poster__asked">Posted : {this.post.date}</p>
                <div className="post-posterinfo">
                    {this.props.avatar}
                    <div className="post-poster__name">{this.post.writer}</div>
                </div>
            </aside>
            <section className="post-question__content">
                <h2>{this.post.title}</h2>
                <p>{this.post.content}</p>
            </section>
            <section className="post-comments">
                {this.post.comments.map((comment, index) => (<div className="comment" key={index}>
                    <div className="comment-details">
                        <span>{comment.writer}</span>
                        <span>{comment.date} </span>
                        <span>{comment.score}</span>
                    </div>
                    <div className="comment-content">
                        {comment.content}
                    </div>
                </div>))}
            </section>
        </article>
        </>)
    }
}

export default Post