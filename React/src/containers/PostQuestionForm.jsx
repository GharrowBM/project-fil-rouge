import React from "react"
import {connect} from "react-redux";
import {submitNewPost} from "../store/actions/postsActions";
import '../styles/containers/PostQuestionForm.css';

class PostQuestionForm extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            title: "",
            content: "",
        }
    }

    postPostFromForm(e) {

        e.preventDefault()

        if (this.state.title && this.state.content) {

            const newPost = {
                title: this.state.title,
                content: this.state.content,
                userId: this.props.currentUser.id
            }

            this.props.submitNewPost(newPost)
        }
    }

    render() {
        return(<>
            <form className="form-add-question">
                <fieldset className="form-add-question__title">
                    <label htmlFor="title">title</label>
                    <textarea type="text" name="title" id="title" value={this.state.title} onChange={(e) => this.setState({title: e.currentTarget.value})}></textarea>
                </fieldset>
                <fieldset className="form-add-question__content">
                    <label htmlFor="content">content</label>
                    <textarea name="content" id="content" value={this.state.content} onChange={(e) => this.setState({content: e.currentTarget.value})}></textarea>
                </fieldset>

                <button onClick={(e) => this.postPostFromForm(e)}>Add Question</button>
            </form>
        </>)
    }
}

const mapStateToProps = (state) => {
    return {
        loading: state.posts.isLoading,
        currentUser: state.users.currentUser
    }
}

const mapActionToProps = (dispatch) => {
    return {
        submitNewPost: (post) => dispatch(submitNewPost(post))
    }
}

export default connect(mapStateToProps, mapActionToProps)(PostQuestionForm)