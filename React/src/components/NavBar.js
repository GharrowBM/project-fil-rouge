import {Link, Redirect} from "react-router-dom"
import React from 'react'
import {connect} from "react-redux";
import {searchPosts} from "../store/actions/postsActions";
import '../styles/components/NavBar.css';

class NavBar extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            inputValue: ""
        }
    }

    searchPosts(e) {
        e.preventDefault()

        console.log(`searchQuery: ${this.state.inputValue}`)

        this.props.searchPosts(this.state.inputValue)
        return (<Redirect to={'/'}/>)
    }

    render () {

        return (
            <nav className="header-navbar">
                    <Link to="/">Home</Link>
                    <div className="search-area">
                    <label className="search-label">root@fil-rouge</label>
                    <input type="text" name="search-input" id="search-input" placeholder="Your search..." value={this.inputValue} onChange={(e) => this.setState({inputValue: e.currentTarget.value})}/>
                    <button className="search-submit" onClick={(e) => this.searchPosts(e)}>Search</button>
                    </div>
                {this.props.currentUser ? <Link to="/">Log Out</Link> : <Link to="/signin">Sign In</Link>}
                {this.props.currentUser ? <Link to="/question/add">Add a question</Link> : <Link to="/register">Sign Up</Link>}
                {this.props.currentUser ? <Link to="/accountdetails">{this.props.currentUser.username}</Link> : null}
            </nav>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.users.isLoading,
        currentUser: state.users.currentUser
    }
}

const mapActionToProps = (dispatch) => {
    return {
        searchPosts: (searchString) => dispatch(searchPosts(searchString))
    }
}

export default connect(mapStateToProps, mapActionToProps)(NavBar)