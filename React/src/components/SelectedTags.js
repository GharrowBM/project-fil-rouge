import React from 'react'

class SelectedTags extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            selectedTags: ['React', 'Typescript']
        }
    }


    render() {
        return(<div className='selected-tags'>
            {this.state.selectedTags.map((tag,index) => <div key={index}>{tag}</div>)}
        </div>)
    }
}

export default SelectedTags