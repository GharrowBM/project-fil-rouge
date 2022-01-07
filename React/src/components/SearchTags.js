import React from 'react'

class SearchTags extends React.PureComponent {
    constructor(props) {
        super(props)
    }

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

export default SearchTags