import React from 'react'
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'
import {fetchInfos} from "../store/actions/infosActions";
import {connect} from "react-redux";

class Home extends React.PureComponent {

    constructor(props) {
        super(props)
    }

    componentDidMount() {
        this.props.fetchInfos()
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
                    <SearchTags tags={this.props.tags} />
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
        loading: state.infosStore.isLoading,
        posts: state.infosStore.posts,
        tags: state.infosStore.tags,
    }
}

const mapActionToProps = (dispatch) => {
    return {
        fetchInfos: () => dispatch(fetchInfos())
    }
}

export default connect(mapStateToProps, mapActionToProps)(Home)