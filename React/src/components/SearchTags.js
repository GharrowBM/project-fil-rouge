import React from 'react'

class SearchTags extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            availableTags: props.availableTags
        }
    }

    render() {

        if (this.state.availableTags !== undefined) {
            return(<div className="search-tags">
                {this.state.availableTags.map((tag,index) => <div key={index}>{tag.name}</div>)}
            </div>)
        }
        else {
            return(<div className="search-tags">
                <p className="empty-div">Loading...</p>
            </div>)
        }

    }
}

export default SearchTags