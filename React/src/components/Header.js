import NavBar from './NavBar'
import React from 'react'
import '../styles/components/Header.css';

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