import NavBar from './NavBar'
import React from 'react'

class Header extends React.PureComponent {
    render () {
        return(
            <header>
                <NavBar />
            </header>
        )
    }
}

export default Header;