import React from "react"
import {postPost, postUserData} from "../services/dataService";
import {connect} from "react-redux";

class PostQuestionForm extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            title: "",
            content: "",
        }
    }

    componentDidMount(){
        console.log(this.props.user.id)
  }

    postPostFromForm(e) {

        e.preventDefault()

        if (this.state.title && this.state.content) {
            const newPost = {
                title: this.state.title,
                content: this.state.content,
                userId: this.props.user.id
            }

            postPost(newPost).then(res => {
                console.log(res.data)
            })
        }
    }

    render() {
        return(<>
            <form className="form-add-question">
                <fieldset>
                    <label htmlFor="title">title</label>
                    <input type="text" name="title" id="title" value={this.state.title} onChange={(e) => this.setState({title: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="content">content</label>
                    <input type="textarea" name="content" id="content" value={this.state.content} onChange={(e) => this.setState({content: e.currentTarget.value})}/>
                </fieldset>

                <button onClick={(e) => this.postPostFromForm(e)}>Poster une question</button>
            </form>
        </>)
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.postsStore.isLoading,
        user: state.usersStore.user
    }
}

const mapActionToProps = (dispatch) => {
    return {
        
    }
}

export default connect(mapStateToProps, mapActionToProps)(PostQuestionForm)