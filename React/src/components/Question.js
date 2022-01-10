import React from 'react'
import {Link, withRouter} from 'react-router-dom'
import BASEAVATAR from '../assets/baseAvatar2wCircle.svg'
import '../styles/components/Question.css';
import {updateCommentAction} from "../store/actions/postsActions";
import {connect} from "react-redux";

class Question extends React.PureComponent {
    constructor(props) {
        super(props)
    }

    getAvatar(writerId) {
        if (this.props.allAvatarPath.find(x => x.userId === this.props.post.id)) {
            const path = this.props.allAvatarPath.find(x => x.userId === this.props.post.id).avatarPath
            console.log(path)
            return (
                <img
                    src={path.toString()}
                    alt={this.props.post.user.username}
                    className="post-poster__avatar"
                />
            );
        }

        else
            return (
                <img
                    src={BASEAVATAR}
                    alt="writer avatar"
                    className="post-poster__avatar"
                />
            )
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
                {this.getAvatar(this.props.post.user)}
                    <div className="forum-poster__name">{this.props.post.user?.username}</div>
                </div>
            </aside>
        </article>
        </>)
    }
}

const mapStateToProps = (state) => {
    return {
        allAvatarPath: state.posts.allAvatarPath
    }
}

export default connect(mapStateToProps, null)(withRouter(Question))