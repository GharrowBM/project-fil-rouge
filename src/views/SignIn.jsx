import React from 'react'
import Header from '../components/Header'
import { baseUsers } from '../datas/baseData'

class SignIn extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            mail: "",
            password: ""
        }
    }

    testSignin(mail, pass) {

        const tmpUser = baseUsers.find(x => x.mail === mail)

        console.log(tmpUser.password === pass ? 'Login Successful' : 'Login Failed')
    }

    componentDidMount() {
        console.log(baseUsers)
    }

    handleSubmit() {

    }


    render() {
        return(<>
            <Header />
            <form className="form-signin" onSubmit={(e) => e.preventDefault()}>
            <fieldset>
                    <legend>Email</legend>
                    <input type="mail" name="input-mail" id="input-mail" value={this.state.mail} onChange={(e) => this.setState({mail: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <legend>Mot de passe</legend>
                    <input type="password" name="input-password" id="input-password" value={this.state.password} onChange={(e) => this.setState({password: e.currentTarget.value})}/>
                </fieldset>
                <button onClick={() => this.testSignin(this.state.mail, this.state.password)}>Se connecter</button>
            </form>

        </>)
    }
}

export default SignIn