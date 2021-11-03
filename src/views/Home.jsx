import React from 'react'
import Header from "../components/Header"
import SearchTags from '../components/SearchTags'
import SelectedTags from '../components/SelectedTags'

class Home extends React.PureComponent {
    render() {
        return (<>
            <Header />
            <div className="tags-area">
                <SelectedTags />
            <SearchTags />
            </div>
            
        </>)
    }
}

export default Home