import {Link} from "react-router-dom"
import React from 'react'

class NavBar extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            inputValue: ""
        }
    }

    render () {

        const appName='fil-rouge'

        return (
            <nav className="header-navbar">
                    <Link to="/">Accueil</Link>
                    <div className="search-area">
                    <label className="search-label">root@{appName}$ </label>
                    <input type="text" name="search-input" id="search-input" placeholder="Rechercher..." value={this.inputValue} onChange={(e) => this.setState({inputValue: e.currentTarget.value})}/>
                    </div>
                {this.props.isLoggedIn ? <Link to="/">Déconnection</Link> : <Link to="/signin">Se connecter</Link>}
                {this.props.isLoggedIn ? <Link to="/question/add">Ajouter une question</Link> : <Link to="/register">S'enregistrer</Link>}
                    <Link to="/about">A propos</Link>
            </nav>
        )
    }
}

export default NavBar;