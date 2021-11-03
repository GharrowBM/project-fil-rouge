import React from 'react'
import Header from "../components/Header"
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'

class Home extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            baseForums: props.baseForums,
            baseTags: props.baseTags,
            baseUsers: props.baseUsers,
        }
    }

    componentDidMount() {
        // console.log(this.state.baseForums);
    }

    render() {
        return (<>
            <Header />
            <div className="tags-area">
                <SelectedTags />
            <SearchTags />
            </div>
            {this.state.baseForums.map((forum,index) => <Question key={index} forum={forum}/>)}
        </>)
    }
}

export default Home