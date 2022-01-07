import React from 'react'
import Header from '../components/Header'
import { loginUser } from '../services/data'

class SignIn extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            username: "",
            password: "",
            isLoggedIn: props.isLoggedIn,
            token: props.token
        }
    }

    // testSignin(username, pass) {

    //     const tmpUser = baseUsers.find(x => x.username === username);
    //     const loginError = document.querySelector(".loginerror")

    //     tmpUser?.password === pass ? window.location = "/" : loginError.innerHTML = "Erreur"

    //     console.log(tmpUser?.password === pass ? 'Login Successful' : 'Login Failed')
    // }

    signInUser(e) {

        e.preventDefault()

        if (this.state.username !== undefined && this.state.password !== undefined) {
            const formdata = new FormData()
            formdata.append("username", this.state.username)
            formdata.append("password", this.state.password)

            loginUser(formdata).then(res => {
                this.props.passConnectionToParent(res.data.token, true, res.data.userId)

            })
        }
    }


    handleSubmit() {

    }


    render() {
        return(<>
            <Header />
            <form className="form-signin">
            <fieldset>
                <label htmlFor="username">username</label>
                    <input type="text" name="username" id="username" value={this.state.username} onChange={(e) => this.setState({username: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="password">password</label>
                    <input type="password" name="password" id="password" value={this.state.password} onChange={(e) => this.setState({password: e.currentTarget.value})}/>
                </fieldset>
                <button onClick={(e) => this.signInUser(e)}>Se connecter</button>
                <div className="loginerror"></div>
            </form>

        </>)
    }
}

export default SignIn