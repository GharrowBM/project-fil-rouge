import React from 'react'
import Incrementals from '../components/Incrementals';
import {connect} from "react-redux";
import '../styles/containers/About.css';


class About extends React.PureComponent {

    constructor(props) {
        super(props)
    }

    render() {
        return (<>
        <article className="about">
        <div className="forum-stats">
            <div className="forum-post-number">
                <div>Questions</div>
                <Incrementals>{this.props.allPosts?.length}</Incrementals>
            </div>
            <div className="forum-users-number">
                <div>Users</div>
                <Incrementals>{this.props.nbOfUsers}</Incrementals>
            </div>
            <div className="forum-tags-number">
                <div>Tags</div>
                <Incrementals>{this.props.allTags?.length}</Incrementals>
            </div>
        </div>
        </article>
        {this.props.currentUser ? <article className="about-user">

        </article> : null}
        </>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        allPosts: state.posts.allPosts,
        allTags: state.posts.allTags,
        nbOfUsers: state.posts.nbOfUsers
    }
}

const mapActionToProps = (dispatch) => {
    return {

    }
}

export default connect(mapStateToProps, mapActionToProps)(About)