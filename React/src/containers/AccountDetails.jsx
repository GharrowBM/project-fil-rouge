import React from "react";
import {connect} from "react-redux";
import {updateUserAction} from "../store/actions/usersActions";
import '../styles/containers/AccountDetails.css';
import Incrementals from "../components/Incrementals";

class AccountDetails extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            username: this.props.currentUser.username,
            email: this.props.currentUser.email,
            password: this.props.currentUser.password,
            firstName: this.props.currentUser.firstName,
            lastName: this.props.currentUser.lastName,
            avatar: undefined
        }
    }

    updateUserInfos = (e) => {
        e.preventDefault()

        const formdata = new FormData()
        formdata.append('username', this.state.username)
        formdata.append('file', this.state.avatar)
        formdata.append('email', this.state.email)
        formdata.append('password', this.state.password)
        formdata.append('lastname', this.state.lastName)
        formdata.append('firstname', this.state.firstName)

        this.props.updateUserAction(this.props.currentUser.id, formdata)
    }

    onChangeFile = (e) => {
        this.setState({avatar: e.target.files[0]})
    }

    render() {
        return (
            <section className="accountDetails">
                <h1>View and update your personal information</h1>
            <form className="form-accountDetails">
                <fieldset>
                    <label htmlFor={"username"}>username</label>
                    <input type={"text"} value={this.state.username} placeholder={"Username"} name={"username"} onChange={(e) => this.setState({username: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor={"password"}>password</label>
                    <input type={"text"} value={this.state.password} placeholder={"Password"} name={"password"} onChange={(e) => this.setState({password: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor={"firstname"}>firstname</label>
                    <input type={"text"} value={this.state.firstName} placeholder={"Firstname"} name={"firstname"} onChange={(e) => this.setState({firstName: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor={"lastname"}>lastname</label>
                    <input type={"text"} value={this.state.lastName} placeholder={"Lastname"} name={"lastname"} onChange={(e) => this.setState({lastName: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor={"email"}>email</label>
                    <input type={"text"} value={this.state.email} placeholder={"Email"} name={"email"} onChange={(e) => this.setState({email: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor={"avatar"}>avatar</label>
                    <input type={"file"} name={"avatar"} onChange={this.onChangeFile}/>
                </fieldset>
                <button onClick={(e) => this.updateUserInfos(e)}>Update info</button>
            </form>
            </section>)
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
        updateUserAction: (id, data) => dispatch(updateUserAction(id, data))
    }
}

export default connect(mapStateToProps, mapActionToProps)(AccountDetails)