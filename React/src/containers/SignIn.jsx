import React from 'react'
import { loginUserAction } from '../store/actions/usersActions'
import {connect} from "react-redux";

class SignIn extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            username: "",
            password: ""
        }
    }

    signInUser(e) {

        e.preventDefault()

        if (this.state.username !== undefined && this.state.password !== undefined) {
            const credentials = {
                username: this.state.username,
                password: this.state.password
            }
            this.props.loginUserAction(credentials)
        }
    }

    render() {
        return(<>
            
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

const mapStateToProps = (state) => {
    return {
      loading: state.users.isLoading,
      currentUser: state.users.currentUser
    }
  }
  
  const mapActionToProps = (dispatch) => {
    return {
      loginUserAction: (credentials) => dispatch(loginUserAction(credentials))
    }
  }
  
  export default connect(mapStateToProps, mapActionToProps)(SignIn)
