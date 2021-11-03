import React from 'react'
import {baseTags} from '../datas/baseData' 

class SearchTags extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            tags: baseTags
        }
    }

    render() {

        return(<div className="search-tags">
            {this.state.tags.map((tag,index) => <div key={index}>{tag}</div>)}
        </div>)
    }
}

export default SearchTags