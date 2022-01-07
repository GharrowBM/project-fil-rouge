import React from 'react'
import Incrementals from '../components/Incrementals';
import {submitNewPost} from "../store/actions/postsActions";
import {connect} from "react-redux";


class About extends React.PureComponent {

    constructor(props) {
        super(props)
    }

    render() {
        return (
        <article className="about">
            <div className="forum-stats">
                <div className="forum-post-number">
                    <h2>Nombre de questions posées</h2>
                    <Incrementals>{this.props.allPosts?.length-1}</Incrementals>
                </div>

                <div className="forum-tags-number">
                    <h2>Nombre total de tags</h2>
                    <Incrementals>{this.props.allTags?.length-1}</Incrementals>
                </div>
            </div>
        </article>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        allPosts: state.posts.allPosts,
        allTags: state.posts.allTags
    }
}

const mapActionToProps = (dispatch) => {
    return {

    }
}

export default connect(mapStateToProps, mapActionToProps)(About)