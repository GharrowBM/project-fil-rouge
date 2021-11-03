import React from 'react'
import Header from '../components/Header'

class Register extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            nickname: "",
            mail: "",
            mailVerif: "",
            password: "",
            passwordVerif: ""
        }
    }

    render() {
        return(<>
            <Header />
            <form action="submit" className="form-register">
            <fieldset>
                    <legend>Nom d'utilisateur</legend>
                    <input type="text" name="input-nickname" id="input-nickname" value={this.state.nickname} onChange={(e) => this.setState({nickname: e.currentTarget.value})}/>
                </fieldset>
            <fieldset>
                    <legend>Email</legend>
                    <input type="mail" name="input-mail" id="input-mail" value={this.state.mail} onChange={(e) => this.setState({mail: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <legend>Vérification Email</legend>
                    <input type="mail" name="input-mail-verif" id="input-mail-verif" value={this.state.mailVerif} onChange={(e) => this.setState({mailVerif: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <legend>Mot de passe</legend>
                    <input type="password" name="input-password" id="input-password" value={this.state.password} onChange={(e) => this.setState({password: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <legend>Vérification Mot de passe</legend>
                    <input type="password" name="input-password-verif" id="input-password-verif" value={this.state.passwordVerif} onChange={(e) => this.setState({passwordVerif: e.currentTarget.value})}/>
                </fieldset>

                <button type="submit">Envoyer</button>
            </form>
        </>)
    }
}

export default Register