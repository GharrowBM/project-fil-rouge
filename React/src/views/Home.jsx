import React from 'react'
import Header from "../components/Header"
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'
import Question from '../components/Question'

class Home extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            baseQuestions: props.baseQuestions,
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
                <div>
                    <h2>Selected tags :</h2>
                <SelectedTags />
                </div>
                <div>
                    <h2>Available tags :</h2>
                    <SearchTags />
                </div>
            </div>
            {this.state.baseQuestions?.map((forum,index) => <Question key={index} forum={forum}/>)}
        </>)
    }
}

export default Home