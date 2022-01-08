import React from "react";

class Incrementals extends React.PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            currentValue: 0,
            isIncremented: false
        }
    }

    componentDidMount() {
        this.interval = setInterval(() => {
            if (this.state.currentValue < this.props.children) {
                this.setState({currentValue: this.state.currentValue+1});
            }},100)
    }
           

    componentWillUnmount() {
        clearInterval(this.interval);
      }

    render() {
        return (
          <p>{this.state.currentValue}</p>
        )
    }
}

export default Incrementals