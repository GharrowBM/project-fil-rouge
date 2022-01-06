import React from 'react'

class SelectedTags extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            currentUserId: props.currentUserId,
            selectedTags: props.currentUserId?.favoriteTags
        }
    }


    render() {
        if (this.state.selectedTags !== undefined) {
            return(<div className='selected-tags'>
                {this.state.selectedTags.map((tag,index) => <div key={index}>{tag}</div>)}
            </div>)
        } else {
            return(<div className='selected-tags'>
                <p className="empty-div">Not Logged in...</p>
            </div>)
        }

    }
}

export default SelectedTags