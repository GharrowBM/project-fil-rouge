import NavBar from './NavBar'
import React from 'react'

class Header extends React.PureComponent {
    render () {
        return(
            <header>
                <NavBar isLoggedIn={this.props.isLoggedIn}/>
            </header>
        )
    }
}

export default Header;