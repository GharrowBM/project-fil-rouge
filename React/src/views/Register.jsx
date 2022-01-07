import React from 'react'
import Header from '../components/Header'
import {postUserData} from "../services/dataService";

class Register extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            username: "",
            email: "",
            emailVerif: "",
            password: "",
            passwordVerif: "",
            firstname: "",
            lastname: "",
            avatar: "",
            isLoggedIn: props.isLoggedIn,
            token: props.token
        }
    }

    postUserFromForm(e) {

        e.preventDefault()

        if (this.state.email === this.state.emailVerif && this.state.password === this.state.passwordVerif) {

            const formdata = new FormData()
            formdata.append('username', this.state.username)
            formdata.append('file', this.state.avatar)
            formdata.append('email', this.state.email)
            formdata.append('password', this.state.password)
            formdata.append('lastname', this.state.lastname)
            formdata.append('firstname', this.state.firstname)

            postUserData(formdata).then(res => {
                this.setState({token: res.data, isLoggedIn: true})
                console.log(this.state.token)
            })
        }
    }

    onChangeFile = (e) => {
        this.setState({avatar: e.target.files[0]})
    }

    render() {
        return(<>
            <Header />
            <form className="form-register">
                <div className="website-conditions">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsam cupiditate deserunt assumenda, blanditiis iure in impedit iusto fuga sapiente saepe provident ipsa eos quisquam voluptatum placeat quaerat nostrum veniam eaque!
                    Praesentium, doloribus quo! Velit iure, vitae veniam nesciunt obcaecati corporis deleniti fugiat aspernatur incidunt reiciendis deserunt perferendis eum non doloremque, assumenda omnis illum veritatis inventore numquam similique a, autem quo.
                    Laborum doloremque quasi ad dignissimos eos omnis sunt, totam eius nam ipsum optio similique voluptatem facilis error, porro fugiat natus in quibusdam voluptate sint officia. Illo animi non atque modi?
                    Provident eaque nostrum consequatur ratione minus, maxime, dolor eum amet ipsum consectetur asperiores quia eius praesentium neque dolorum perferendis facilis nulla nobis odit? Consequuntur earum ab in consequatur blanditiis molestias?
                    Aspernatur omnis iure id quod repellat accusamus magnam iste quo architecto. Quisquam, aspernatur tempore? Quae cum velit nobis at! Autem explicabo magni dolore doloremque delectus, voluptatum blanditiis aut quibusdam sint?
                    Voluptatem corporis vel earum ipsam fuga aut, officiis vitae dolore obcaecati suscipit itaque omnis accusantium eaque perferendis alias assumenda! Pariatur amet recusandae nulla tenetur alias aliquid, rerum tempora architecto sint.
                    Dolorum natus mollitia saepe earum tempore nemo commodi enim eveniet quis sunt quam eum, repellendus culpa animi tenetur eaque voluptas, eligendi deserunt! Possimus voluptas aliquid, amet dolore natus aut quae!
                    Quibusdam iure, veniam repellat similique assumenda, corporis eligendi minus maiores fuga nulla atque doloribus quas, voluptatem distinctio aliquid tempore! Atque recusandae distinctio minima! Corporis cupiditate doloremque dolores debitis voluptate deserunt?
                    Autem natus commodi doloribus aliquid molestiae eaque minima assumenda totam quibusdam magnam optio eveniet minus adipisci, fugiat provident ea deleniti quis alias, excepturi dolores iste voluptas omnis. Atque, fuga odio.
                    Molestias reiciendis pariatur quibusdam obcaecati recusandae ab eos culpa similique, repellat dolor voluptatum repellendus saepe libero ipsum autem dolore, maxime quod ullam ex aspernatur animi aut cum modi doloribus. Dolores.
                    Hic nulla natus eum debitis ullam similique delectus impedit magni asperiores, enim distinctio animi necessitatibus nihil quibusdam dolor. Quam vel necessitatibus ipsa sit exercitationem modi veniam iste sapiente eveniet unde!
                    Repellendus ad ut magni, eveniet nemo animi error fuga? Sint explicabo repellat animi repudiandae a qui, iste temporibus blanditiis nemo? Vero nesciunt obcaecati ab. Exercitationem enim aut culpa illo minima?
                    Labore libero beatae, nulla veritatis officia corporis eaque enim pariatur quis iusto suscipit ducimus harum laboriosam ipsam sit mollitia? Qui, eaque deleniti eos optio quis vitae libero explicabo eveniet quo.
                    Qui beatae cum nam, soluta saepe iste accusamus quas blanditiis laborum ipsa deserunt id recusandae excepturi nisi dolor eligendi assumenda ratione voluptates provident et velit! Accusamus eius porro dignissimos facilis.
                    Cupiditate eaque dolorum exercitationem, beatae nisi porro nulla at dignissimos molestiae qui omnis voluptas officia officiis ut delectus laudantium pariatur nemo laborum libero reiciendis eum modi perspiciatis architecto! Ipsum, voluptatum!
                    Temporibus quae explicabo odit accusamus similique. Nihil libero nulla esse, ducimus soluta harum sapiente molestias, architecto rerum ipsam accusamus expedita est quam a ut odio! Maiores rerum fuga voluptate necessitatibus?
                    Praesentium fuga corrupti molestias nostrum debitis, et ducimus, consequatur dicta harum, ex in distinctio maiores saepe! Ullam repellendus eligendi consectetur reiciendis beatae. Excepturi sed omnis eos ex dolores nemo qui.
                    Molestias provident aut quod iste nihil. Ducimus voluptas hic delectus magnam porro eveniet est aut praesentium consequuntur autem. Consectetur ullam velit natus magnam autem officia sed vel quaerat, inventore dignissimos?
                    Nemo eaque, deserunt doloremque iste corrupti voluptates. Saepe, rerum impedit minus velit, quia id iure cum ex neque cupiditate, vitae eos! Doloribus deleniti nobis fugit veritatis, excepturi eos quam accusamus!
                    Ducimus minus, enim magni incidunt inventore explicabo neque ad. Quae cumque esse temporibus nihil dolores, voluptatem modi itaque cupiditate repudiandae eveniet perferendis enim sunt nisi commodi eius atque. Enim, vel.
                    Magnam earum aut officia doloremque placeat. Suscipit maiores ipsum quam minus vitae voluptas, quae esse. Dolorem commodi illum eveniet facere repellat soluta, corporis, vitae molestias voluptatem, reprehenderit fugit dolore distinctio?
                    Quis molestias esse voluptatibus quisquam nihil perspiciatis ipsam eligendi architecto, pariatur corrupti iure? Amet libero modi laborum dolorem deserunt? Doloremque esse culpa est. Laborum unde porro necessitatibus sint, culpa dolorum.
                    Quidem corporis iure impedit, dolorem quos neque provident obcaecati sapiente. Temporibus tempore error corrupti illo accusamus nam nobis quis dignissimos necessitatibus, harum repudiandae voluptate assumenda odit enim! Necessitatibus, eveniet est?
                    Provident inventore mollitia officia laudantium optio adipisci voluptas ipsa? Deleniti vitae ut iste odit accusantium in illo dicta quae ratione expedita tempora nesciunt optio perferendis exercitationem eos, tenetur esse excepturi!
                    Officiis quos commodi, molestiae expedita autem est aspernatur ipsam molestias porro nobis tempore obcaecati corporis suscipit aliquid, eligendi delectus in velit laudantium. Omnis, nobis laudantium. Obcaecati iure totam est voluptas.
                </div>
                <fieldset>
                    <label htmlFor="firstname">firstname</label>
                    <input type="text" name="firstname" id="firstname" value={this.state.firstname} onChange={(e) => this.setState({firstname: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="lastname">lastname</label>
                    <input type="text" name="lastname" id="lastname" value={this.state.lastname} onChange={(e) => this.setState({lastname: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="username">username</label>
                    <input type="text" name="username" id="username" value={this.state.username} onChange={(e) => this.setState({username: e.currentTarget.value})}/>
                </fieldset>
            <fieldset>
                    <label htmlFor="email">mail</label>
                    <input type="mail" name="email" id="email" value={this.state.email} onChange={(e) => this.setState({email: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="email-verif">verifMail</label>
                    <input type="mail" name="email-verif" id="email-verif" value={this.state.emailVerif} onChange={(e) => this.setState({emailVerif: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="password">password</label>
                    <input type="password" name="password" id="password" value={this.state.password} onChange={(e) => this.setState({password: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                    <label htmlFor="password-verif">verifPassword</label>
                    <input type="password" name="password-verif" id="password-verif" value={this.state.passwordVerif} onChange={(e) => this.setState({passwordVerif: e.currentTarget.value})}/>
                </fieldset>
                <fieldset>
                <label htmlFor="file">avatar</label>
                <input type="file" name="file" id="file" onChange={this.onChangeFile}/>
            </fieldset>

                <button onClick={(e) => this.postUserFromForm(e)}>S'enregistrer</button>
            </form>
        </>)
    }
}

export default Register