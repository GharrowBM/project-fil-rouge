import React from 'react'
import Header from "../components/Header"
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'
import {fetchPosts} from "../store/actions/postsActions";
import {connect} from "react-redux";

class Home extends React.PureComponent {

    constructor(props) {
        super(props)
    }

    render() {
        return (<>
            <Header />
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
            {/* {}
            if (this.state.basePosts?.length > 0) {
                {this.state.basePosts?.map((forum,index) => <Question key={index} forum={forum}/>)}
            } */}
            {this.props.posts !== undefined ? this.props.posts?.map((post,index) => <Question key={index} post={post}/>) : <> </>}
            
        </>)
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.postsStore.isLoading,
        posts: state.postsStore.posts
    }
}

const mapActionToProps = (dispatch) => {
    return {
        fetchPosts: () => dispatch(fetchPosts())
    }
}

export default connect(mapStateToProps, mapActionToProps)(Home)