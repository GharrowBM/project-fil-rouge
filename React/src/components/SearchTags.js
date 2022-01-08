import React from 'react'
import {connect} from "react-redux";
import '../styles/components/SearchTags.css';

class SearchTags extends React.PureComponent {

    render() {

        if (this.props.tags !== undefined) {
            return(<div className="search-tags">
                {this.props.tags.map((tag,index) => <div key={index}>{tag.name}</div>)}
            </div>)
        }
        else {
            return(<div className="search-tags">
                <p className="empty-div">Loading...</p>
            </div>)
        }

    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        tags: state.posts.allTags
    }
}

export default connect(mapStateToProps, null)(SearchTags)