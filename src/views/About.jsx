import React from 'react'
import Incrementals from '../components/Incrementals';
import Header from '../components/Header';


class About extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
        baseQuestions: props.allQuestions,
        baseTags: props.allTags,
        baseUsers: props.allUsers
        }
    }

    mostActiveUser() {
        let maxActiveUser = "";
        let previousUser = 0;

        this.props.allUsers.forEach(user => {

            let currentUser = 0;

            this.props.allQuestions.forEach(question => {

                question.posts.forEach(post1 => {

                    if (post1.writer === user.name) {
                        currentUser++;
                    }
                    post1.comments.forEach(comment => {
                        if (comment.writer === user.name) {
                            currentUser++;
                        }
                    });
                });
                
            });

            if (currentUser > previousUser) {
                previousUser = currentUser;
                maxActiveUser = user.name;
            }
        })

        return maxActiveUser;
    }

    render() {
        return (
        <article className="about">
            <Header />
            <div className="forum-stats">
                <div className="forum-most-active">
                    <h2>Utilisateur le plus actif</h2>
                    <p>{this.mostActiveUser()}</p>
                </div>
                <div className="forum-number-users">
                    <h2>Nombre d'utilisateurs</h2>
                    <Incrementals>{this.props.allUsers.length}</Incrementals>
                </div>
                {/* <div>
                    <h2></h2>
                    <p></p>
                </div> */}
            </div>
        </article>
        )
    }
}

export default About