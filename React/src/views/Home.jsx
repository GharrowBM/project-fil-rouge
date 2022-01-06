import React from 'react'
import Header from "../components/Header"
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'

class Home extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            basePosts: props.basePosts,
            availableTags : props.availableTags,
            selectedTags : props.selectedTags
        }
    }

    render() {
        return (<>
            <Header />
            <div className="tags-area">
                <div>
                    <h2>Selected tags :</h2>
                <SelectedTags selectedTags={this.state.selectedTags}/>
                </div>
                <div>
                    <h2>Available tags :</h2>
                    <SearchTags availableTags={this.state.availableTags}/>
                </div>
            </div>
            {this.state.basePosts?.map((forum,index) => <Question key={index} forum={forum}/>)}
        </>)
    }
}

export default Home