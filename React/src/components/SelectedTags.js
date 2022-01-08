import React from 'react'
import {connect} from "react-redux";
import '../styles/components/SelectedTags.css';

class SelectedTags extends React.PureComponent {
    render() {
        if (this.props.selectedTags !== undefined) {
            return(<div className='selected-tags'>
                {this.props.selectedTags.map((tag,index) => <div key={index}>{tag.name}</div>)}
            </div>)
        } else {
            return(<div className='selected-tags'>
                <p className="empty-div">Not Selected Tags...</p>
            </div>)
        }

    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        selectedTags: state.users.currentUser?.favoriteTags
    }
}

export default connect(mapStateToProps, null)(SelectedTags)