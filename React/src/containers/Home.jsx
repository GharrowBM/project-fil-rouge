import React from 'react'
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'
import {fetchAllPostsWithTags} from "../store/actions/postsActions";
import {connect} from "react-redux";

class Home extends React.PureComponent {

    componentDidMount() {
        this.props.fetchAllPostsWithTags()
    }

    render() {
        return (<>
            
            <div className="tags-area">
                <div>
                    <h2>Selected tags :</h2>
                <SelectedTags />
                </div>
                <div>
                    <h2>Available tags :</h2>
                    <SearchTags />
                </div>
            </div>

            {this.props.posts !== undefined ? this.props.posts?.map((post,index) => <Question key={index} post={post}/>) : <> </>}
            
        </>)
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        posts: state.posts.allPosts,
        tags: state.posts.allTags
    }
}

const mapActionToProps = (dispatch) => {
    return {
        fetchAllPostsWithTags: () => dispatch(fetchAllPostsWithTags())
    }
}

export default connect(mapStateToProps, mapActionToProps)(Home)